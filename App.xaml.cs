using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Versely.Interfaces;
using Versely.Services;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    public partial class App : Application
    {
        public static ServiceProvider Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            // 🔹 Services
            services.AddSingleton<EmotionService>();
            services.AddSingleton<IDialogService, DialogService>();

            // 🔹 ViewModels
            services.AddTransient<MainViewModel>();

            Services = services.BuildServiceProvider();

            // 🔹 Create main window
            var mainWindow = new MainWindow
            {
                DataContext = Services.GetRequiredService<MainViewModel>()
            };

            mainWindow.Show();
        }
    }
}
