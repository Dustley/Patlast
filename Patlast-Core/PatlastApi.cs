using Patlast_Core.Project;

namespace Patlast_Core;

public class PatlastApi
{
    ////////////////////////
    // Project management //
    ////////////////////////
    public static ProjectInstance CreateProject(string projectName, string projectPath) => new(projectName, projectPath);
    
}