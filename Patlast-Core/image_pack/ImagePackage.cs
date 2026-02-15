using Patlast_Core.image;

namespace Patlast_Core.pack;

public class ImagePackage(string handle, ImagePackData packData)
{
    
    /// <summary>
    /// Handles will always stay the same, and is a good way to reference this image uniquely 
    /// </summary>
    private readonly string _handle = handle;
    public string GetHandle() => _handle;
    
    /// <summary>
    /// Holds the images and the corresponding positions provided by the packer.
    /// </summary>
    private readonly ImagePackData _packData = packData;
    public ImagePackData GetPackData() => _packData;

    /// <summary>
    /// Finds the index for the corresponding image reference.
    /// </summary>
    /// <param name="reference"> The reference and handle that we are trying to find. </param>
    /// <returns> If an image with a handle identical to the reference passed in is found return its index. Otherwise, if nothing is found return -1.</returns>
    public int GetImageIndex(ImageReference reference)
    {
        for (var i = 0; i < _packData.ImageReferences.Length; i++)
        {
            var packDataImageReference = _packData.ImageReferences[i];
            if (packDataImageReference.GetHandle() == reference.GetHandle()) return i;
        }
        return -1;
    }
}