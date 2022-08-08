using LiteDB;
using PackNet.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using Typin;
using Typin.Attributes;
using Typin.Console;
using Typin.Exceptions;

namespace PackNet.Core.Commands.Init;

public class InitCommand : ConsoleAppBase
{
    private readonly IFileService _fileService;

    public InitCommand(IFileService fileService)
    {
        _fileService = fileService;
    }

    [Command("init", "Initialize PackNet package manager for this solution", Manual = @"Creates a folder called 'Nuget/' that will store downloaded packages, and '.packnet' wich will store configs.
Will create a file called 'nuget.config' too for registering the package source. If one already exist then it will be just edited.

* Need a solution file in initialization directory.")]
    public void Init()
    {
        var sln = _fileService.Search("*.sln");
        if (sln is "")
            throw new Exception("No solution file found");
        InitializeDirectories();
        InitializeConfigs();
        InitializeDatabase();
    }
    static void InitializeDirectories()
    {
        Directory.CreateDirectory(".packnet");
        Directory.CreateDirectory("NuGet");
    }
    void InitializeConfigs()
    {
        var nugetConf = _fileService.Search("nuget.config");
        if (nugetConf is "")
            CreateNugetConfig();
        else
            EditNugetConfig(nugetConf);
    }
    static void CreateNugetConfig()
    {
        const string model = 
        @"<?xml version=""1.0"" encoding=""utf-8""?>
        <configuration>
          <packageSources>
            <add key=""nuget.org"" value=""https://api.nuget.org/v3/index.json"" protocolVersion=""3"" />
            <add key=""WiProtect-Feed"" value=""./NuGet"" />
          </packageSources>
        </configuration>";
        File.WriteAllText("nuget.config", model);
    }
    static void EditNugetConfig(string config)
    {
        var xml = XDocument.Parse(File.ReadAllText(config));
        var sources = xml.XPathSelectElement("/configuration/packageSources");
        if (sources is null)
            throw new Exception("Your already existent nuget.config is not valid");

        var source = new XElement("add");
        source.SetAttributeValue("key", "PackNet");
        source.SetAttributeValue("value", "./NuGet");

        sources.Add(source);

        sources.Save(config);
    }
    static void InitializeDatabase()
    {
        new LiteDatabase("filename=.packnet/repos.db")
            .Dispose();
    }
}
