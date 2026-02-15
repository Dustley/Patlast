using ImageMagick;

namespace Patlast_Core.image;

/// <summary>
/// Represents a single "atlas" or "pack".
/// This stores 
/// </summary>
public class ImagePack
{
    
    /// <summary>
    /// Handles will always stay the same, and is a good way to reference this image uniquely 
    /// </summary>
    private readonly string _handle;
    public string GetHandle() => _handle;
    
    private ImageReference[] _imageReferences;
    private (int x, int y)[] _imagePositions;
    
    public ImagePack(string handle, ImageReference[] imageRefs)
    {
        _handle = handle;
        _imageReferences = new ImageReference[imageRefs.Length];
        imageRefs.CopyTo(_imageReferences);
        
        _imagePositions = new (int x, int y)[imageRefs.Length];
    }
    
    public void ArrangeImages(bool prioritizeHeight = false)
    {
        var dimensions = GetArrangementDimensions(prioritizeHeight);
        Console.WriteLine($"Pack dimensions: {dimensions}");
    
        for (var i = 0; i < _imageReferences.Length; i++)
        {
            var x = i % dimensions.width;
            var y = i / dimensions.width;
            _imagePositions[i] = (x, y);
        }
    }

    public void ExportImage(string exportPath)
    {
        var outputImage = new MagickImage();
        
    }
    
    public (int width, int height) GetArrangementDimensions(bool swapWidthAndHeight = false)
    {
        var arraySize = _imageReferences.Length;
        if (arraySize <= 0) return (0, 0);
        
        var widthComponent = (int) Math.Ceiling(Math.Sqrt(arraySize));
        var heightComponent = (int) Math.Ceiling((double) arraySize / widthComponent);
        
        return swapWidthAndHeight ? (heightComponent, widthComponent) : (widthComponent, heightComponent);
    }
}