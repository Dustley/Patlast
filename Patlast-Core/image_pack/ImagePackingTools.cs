using Patlast_Core.image;

namespace Patlast_Core.pack;

public class ImagePackingTools
{
    public static Dictionary<int, List<ImageReference>> CalculateImageGroups(List<ImageReference> unsortedImages)
    {
        var groups = new Dictionary<int, List<ImageReference>>();
        
        foreach (var imageReference in unsortedImages)
        {
            var image = imageReference.GetBackendInstance();
            var imageSize = Math.Max(image.Width, image.Height);
            var groupIndex = (int) Math.Pow(2, Math.Ceiling(Math.Log2(imageSize)));
            
            // Create and/or add this image to its group.
            if (groups.TryGetValue(groupIndex, out var value)) value.Add(imageReference);
            else groups.Add(groupIndex, [imageReference]);
        }
        
        return groups;
    }
}