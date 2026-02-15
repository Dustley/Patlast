using Patlast_Core;
using Patlast_Core.pack.packers;
using Patlast_Core.Project;

var project = new ProjectInstance("test", "C:\\\\Users\\\\carte\\\\Pictures\\\\test");
project.AddImageFromPath("a.png");
project.AddImageFromPath("b.png");
project.AddImageFromPath("c.png");

var imagePacker = new FlatImagePacker(true);
var pack = project.PackSingle("hello", imagePacker);
Console.WriteLine(pack.GetPackData().ImageReferences.Length);