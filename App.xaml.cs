using System;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace GenericHostWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;
        public App()
        {
            _host = new HostBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.Configure<ApplicationContext>(context.Configuration);
                    services.AddSingleton<MainWindow>();
                    // services.AddTransient<MainWindow>();
                    // services.AddScoped<MainWindow>();
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
