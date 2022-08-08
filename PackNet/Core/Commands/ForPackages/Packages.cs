using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackNet.Core.Commands.ForAdd;

[Command("")]
public class Packages : ConsoleAppBase
{
    [Command("add", "Add packages to the specified project")]
    public void Add(
        [Option(0, "The project name to install package")] string? projectName, 
        [Option("n", "Use the name as file instead searching for csproj")] bool nameAsFile)
    {
        
    }
}
