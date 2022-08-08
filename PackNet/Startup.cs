using Microsoft.Extensions.DependencyInjection;
using PackNet.Contracts.Services;
using PackNet.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackNet;

public static class Startup
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddSingleton<IFileService, FileService>();
    }
}
