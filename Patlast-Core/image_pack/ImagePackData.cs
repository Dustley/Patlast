using Patlast_Core.image;

namespace Patlast_Core.pack;

public record ImagePackData
{
    // Width and Height of the ENTIRE pack.
    public required int Width { get; init; }
    public required int Height { get; init; }
    
    // The images and where they are stored in the output image.
    public required ImageReference[] ImageReferences { get; init; }
    public required (int, int)[] PositionsA { get; init; }
    public required (int, int)[] PositionsB { get; init; }
};