using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typin.Attributes;

namespace PackNet.Core.Commands.ForAdd;

[Command("add", Description = "Add packages to the specified project")]
public class AddCommand
{
    [CommandParameter(0, Description = "The project name to install package")]
    public string? ProjectName { get; set; }

    [CommandOption("nameAsFile", 'n', Description = "Use the name as file instead searching for csproj")]
    public bool ProjectNameAsFile { get; set; }
}
