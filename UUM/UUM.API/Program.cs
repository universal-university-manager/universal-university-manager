using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace UUM.API
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Boot method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        /// <summary>
        /// Initialize design method
        /// </summary>
        /// <param name="args">args instance</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
