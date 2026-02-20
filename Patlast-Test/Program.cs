using ImageMagick;
using Patlast_Core;
using Patlast_Core.pack.packers;
using Patlast_Core.Project;

var project = new ProjectInstance("test", "C:\\Users\\carte\\Pictures\\test");
project.AddImageFromPath("a.png");
project.AddImageFromPath("b.png");
project.AddImageFromPath("c.png");
project.AddImageFromPath("d.png");
project.AddImageFromPath("e.png");
project.AddImageFromPath("f.png");

var imagePacker = new GridImagePacker();
var packs = project.PackGroups("hello-x", imagePacker);

foreach (var pack in packs)
{
    var export = pack.ExportToFile("C:\\Users\\carte\\Pictures\\output", MagickFormat.Png);
    Console.WriteLine(export);
}

