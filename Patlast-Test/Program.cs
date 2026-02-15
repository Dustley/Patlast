// See https://aka.ms/new-console-template for more information

using Patlast_Core;

Console.WriteLine();

var project = PatlastApi.CreateProject("test", "C:\\\\Users\\\\carte\\\\Pictures\\\\test");
project.AddImageFromPath("a.png");
project.AddImageFromPath("b.png");
project.AddImageFromPath("c.png");
project.ExportAsGroups("C:\\\\Users\\\\carte\\\\Pictures\\\\output");

// project.AddImage("a.png"); // size 16x16
// project.AddImage("b.png"); // size 16x16
// project.AddImage("c.png"); // size 32x32
// project.AddImage("d.png"); // size 16x16
// project.AddImage("e.png"); // size 32x32
// project.AddImage("f.png"); // size 16x16
//
// project.AddAllImages("folderPath");
