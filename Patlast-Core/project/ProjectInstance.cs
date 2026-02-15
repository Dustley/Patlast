using System.Collections;
using ImageMagick;
using Patlast_Core.image;

namespace Patlast_Core.Project;

public class ProjectInstance(string projectName, string projectPath)
{
    
    private string _projectName = projectName;
    private string _projectPath = projectPath;

    private readonly ArrayList _imageReferences = new();
    
    public string GetCombinedPath(string filePath) => Path.Combine(_projectPath, filePath);
    
    // Image handling
    public void AddImageFromPath(string filePath) => AddImage(new ImageReference(GetCombinedPath(filePath)));
    public void AddImage(ImageReference image)
    {
        _imageReferences.Add(image);
    }
    
    // Atlas Generation
    public ImageReference GenerateSingleAtlas(string title, string outputPath, float aspect)
    {
        
    }

    private MagickImage PackImages(ImageReference[] images)
    {
        var packageImage = new MagickImage();
        
    }
}