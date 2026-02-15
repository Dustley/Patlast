using System.Collections;
using ImageMagick;
using Patlast_Core.image;
using Patlast_Core.pack;
using Patlast_Core.pack.packers;

namespace Patlast_Core.Project;

public class ProjectInstance(string projectName, string projectPath)
{
    
    private string _projectName = projectName;
    public string GetProjectName() => _projectName;
    public void SetProjectName(string name) => _projectName = name;
    
    private string _projectPath = projectPath;
    public string GetProjectPath() => _projectPath;
    public void SetProjectPath(string name) => _projectPath = name;
    private string GetCombinedPath(string filePath) => Path.Combine(_projectPath, filePath);
    
    private readonly List<ImageReference> _imageReferences = new();
    
    // Single image adding
    public void AddImageFromPath(string filePath) => AddImage(new ImageReference(GetCombinedPath(filePath)));
    public void AddImage(ImageReference image) => _imageReferences.Add(image);

    // Packing
    public ImagePackage PackSingle(string handle, IImagePacker packer) => new(handle, packer.PackImages(_imageReferences));
    public List<ImagePackage> PackGroups(string handlePrefix, IImagePacker packer)
    {
        var groups = ImagePackingTools.CalculateImageGroups(_imageReferences);
        return groups.Select(keyValuePair => new ImagePackage($"{handlePrefix}{keyValuePair.Key}", packer.PackImages(keyValuePair.Value))).ToList();
    }
}