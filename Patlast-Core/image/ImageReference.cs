using ImageMagick;

namespace Patlast_Core.image;

public class ImageReference
{
    /// <summary>
    /// Handles will always stay the same, and is a good way to reference this image uniquely 
    /// </summary>
    private readonly string _handle;
    public string GetHandle() => _handle;
    
    private string _filePath;
    public void SetFilePath(string newPath) => _filePath = newPath;
    public string GetFilePath() => _filePath;
    
    public ImageReference(string handle, string filePath)
    {
        _handle = handle;
        _filePath = filePath;
        
        var backendInstance = new MagickImage(new FileInfo(filePath));
    }

    public ImageReference(string filePath) : this(new FileInfo(filePath).Name, filePath) {}
}