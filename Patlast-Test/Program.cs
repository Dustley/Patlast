using Patlast_Core;
using Patlast_Core.pack.packers;

var project = PatlastApi.CreateProject("test", "C:\\\\Users\\\\carte\\\\Pictures\\\\test");
project.AddImageFromPath("a.png");
project.AddImageFromPath("b.png");
project.AddImageFromPath("c.png");

var imagePacker = new FlatImagePacker(true);
var pack = project.PackSingle("hello", imagePacker);
Console.WriteLine(pack.GetPackData().ImageReferences.Length);