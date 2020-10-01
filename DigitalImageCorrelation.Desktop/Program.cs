using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Desktop.Drawing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using System;
using System.Windows.Forms;
namespace DigitalImageCorrelation.Desktop
{
    static class Program
    {

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                var host = new HostBuilder()
                       .ConfigureServices((hostContext, services) =>
                       {
                           services.AddScoped<MainForm>();
                           services.AddScoped<Worker>();
                           services.AddSingleton<Painter>();
                           services.AddLogging(option =>
                           {
                               option.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
                               option.AddNLog("nlog.config");
                           });
                       }).Build();

                using (var serviceScope = host.Services.CreateScope())
                {
                    var services = serviceScope.ServiceProvider;
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(services.GetRequiredService<MainForm>());
                }
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Unexpected error occured, unable to continue work. Aplication will be closed");
            }
        }
    }
}
