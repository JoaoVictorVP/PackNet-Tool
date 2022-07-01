using Microsoft.Extensions.DependencyInjection;
using PackNet.Contracts.Services;
using PackNet.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typin;
using Typin.Directives;
using Typin.Modes;

namespace PackNet;

public class Startup : ICliStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IFileService, FileService>();
    }

    public void Configure(CliApplicationBuilder app)
    {
        app.AddCommandsFromThisAssembly()
           .AddDirective<DebugDirective>()
           .AddDirective<PreviewDirective>()
           .UseInteractiveMode();
    }
}
