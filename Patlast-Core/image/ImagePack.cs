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
    private (int,int)[] _imagePositions;
    
    public ImagePack(string handle, ImageReference[] imageRefs)
    {
        _handle = handle;
        _imageReferences = new ImageReference[imageRefs.Length];
        imageRefs.CopyTo(_imageReferences);
        
        _imagePositions = new (int,int)[imageRefs.Length];
    }
}