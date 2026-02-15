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
    public void ExportAsGroups(string exportPath, bool prioritizeHeight = false)
    {
        Console.WriteLine($"Generating atlas and exporting to \"{exportPath}\"...");
        // TODO:
        // 1. Find what groups are needed and sort images into them.
        // 2. For each group find the ideal size

        var packs = new List<ImagePack>();
        var groups = new Dictionary<int, List<ImageReference>>();
        
        for (var i = 0; i < _imageReferences.Count; i++)
        {
            var imageReference = _imageReferences[i] as ImageReference;
            if (imageReference is null) continue;
            
            var image = imageReference.GetBackendInstance();
            var imageSize = Math.Max(image.Width, image.Height);
            var groupIndex = (int) Math.Pow(2, Math.Ceiling(Math.Log2(imageSize)));
            
            // Create and/or add this image to its group.
            if (groups.TryGetValue(groupIndex, out var value)) value.Add(imageReference);
            else groups.Add(groupIndex, [imageReference]);
        }
        
        // For each sorted group we create a proper image pack.
        foreach (var groupArrayPair in groups)
        {
            var packInstance = new ImagePack(groupArrayPair.Key.ToString(), groupArrayPair.Value.ToArray());
            packInstance.ArrangeImages(prioritizeHeight);
            packs.Add(packInstance);
            
            Console.WriteLine($"Added pack with handle \"{packInstance.GetHandle()}\".");
        }
        
        Console.WriteLine($"{packs.Count} packs were added!");
        Console.WriteLine($"Exported to \"{exportPath}\"!");
    }
}