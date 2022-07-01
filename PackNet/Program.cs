using Typin;

namespace PackNet;

public class Program
{
    static async Task<int> Main()
    {
        return await new CliApplicationBuilder()
            .UseStartup<Startup>()
            .Build()
            .RunAsync();
    }
}
