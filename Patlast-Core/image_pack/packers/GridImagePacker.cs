using Patlast_Core.image;

namespace Patlast_Core.pack.packers;

public class GridImagePacker:IImagePacker
{

    private int _padding = 0;

    public GridImagePacker() {}
    public GridImagePacker(int padding = 0)
    {
        _padding = padding;
    }
    
    public ImagePackData PackImages(List<ImageReference> images)
    {
        var imageData = images.ToArray();
        var positionAData = new (int, int)[imageData.Length];
        var positionBData = new (int, int)[imageData.Length];
        
        // Find the largest image in the set. This allows us to use it for the grid size.
        var gridSize = 0;
        foreach (var imageReference in images)
        {
            gridSize = Math.Max(gridSize, (int) imageReference.GetBackendInstance().Width);
            gridSize = Math.Max(gridSize, (int) imageReference.GetBackendInstance().Height);
        }
        gridSize += _padding;
        
        var sideSlotCount = (int) Math.Ceiling(Math.Sqrt(images.Count));
        
        for (var i = 0; i < imageData.Length; i++)
        {
            var imageReference = imageData[i];
            var backendImage = imageReference.GetBackendInstance();
            
            var imageWidth = (int) backendImage.Width;
            var imageHeight = (int) backendImage.Height;

            var xPos = (i % sideSlotCount) * gridSize;
            var yPos = (i / sideSlotCount) * gridSize;
            
            positionAData[i] = (xPos, yPos);
            positionBData[i] = (xPos + imageWidth, yPos + imageHeight);
        }
        
        var totalSize = sideSlotCount * gridSize;
        
        var packData = new ImagePackData
        {
            Width = totalSize,
            Height = totalSize,
            ImageReferences = imageData,
            PositionsA = positionAData,
            PositionsB = positionBData
        };
        return packData;
    }
}