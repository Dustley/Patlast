using Patlast_Core.image;

namespace Patlast_Core.pack.packers;

public class FlatImagePacker(bool stackVertical = false):IImagePacker
{
    public ImagePackData PackImages(List<ImageReference> images)
    {
        var imageData = images.ToArray();
        var positionAData = new (int, int)[imageData.Length];
        var positionBData = new (int, int)[imageData.Length];

        var totalWidth = 0;
        var totalHeight = 0;
        
        for (var i = 0; i < imageData.Length; i++)
        {
            var imageReference = imageData[i];
            var backendImage = imageReference.GetBackendInstance();
            
            var imageWidth = (int) backendImage.Width;
            var imageHeight = (int) backendImage.Height;

            if (stackVertical)
            {
                positionAData[i] = (0, totalHeight);
                
                totalHeight += imageHeight;
                totalWidth = Math.Max(totalWidth, imageWidth);
                
                positionBData[i] = (imageWidth, totalHeight);
            }
            else
            {
                positionAData[i] = (totalWidth, 0);
                
                totalWidth += imageWidth;
                totalHeight = Math.Max(totalHeight, imageHeight);
                
                positionBData[i] = (totalWidth, imageHeight);
            }
        }
        
        var packData = new ImagePackData
        {
            Width = totalWidth,
            Height = totalHeight,
            ImageReferences = imageData,
            PositionsA = positionAData,
            PositionsB = positionBData
        };
        return packData;
    }
}