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
    public void SetFilePath(string newPath)
    {
        _filePath = newPath;
        OnUpdate();
    } 
    public string GetFilePath() => _filePath;
    
    private MagickImage _backendInstance;
    public MagickImage GetBackendInstance() => _backendInstance;
    
    // Constructors
    public ImageReference(string filePath) : this(new FileInfo(filePath).Name, filePath) {}
    public ImageReference(string handle, string filePath)
    {
        _handle = handle;
        _filePath = filePath;
        OnUpdate();
    }

    public void OnUpdate()
    {
        _backendInstance = new MagickImage(new FileInfo(_filePath));
    }
    
}