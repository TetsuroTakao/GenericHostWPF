using System;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GenericHostWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// services.AddTransient<MainWindow>(); onetime per a session
    /// services.AddScoped<MainWindow>(); everytime per request
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;
        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();
                    IHostEnvironment env = hostingContext.HostingEnvironment;
                    configuration
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.Configure<ApplicationContext>(context.Configuration);
                    services.AddSingleton<MainWindow>();
                    // services.AddTransient<MainWindow>();
                })
                .Build();
        }
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
            _host.Services.GetRequiredService<MainWindow>().Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync(TimeSpan.FromSeconds(5));
            _host.Dispose();
        }
    }
}
