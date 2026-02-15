using Patlast_Core.image;

namespace Patlast_Core.pack.packers;

public interface IImagePacker
{
    public ImagePackData PackImages(List<ImageReference> images);
}