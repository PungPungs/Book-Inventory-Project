using Microsoft.Extensions.DependencyInjection;
using StockManagement.Service.API;
using StockManagement.Service.Logger;
using StockManagement.Service.Window;
using StockManagement.View;
using StockManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StockManagement
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            // WindowService를 통해 LoginView 시작 (DataContext 자동 설정됨!)
            var windowService = _serviceProvider.GetRequiredService<IWindowService>();
            windowService.ShowWindow<LoginViewModel>();
        }


        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IWindowService, WindowService>();

            // Logger
            services.AddSingleton<ILogger>(sp => new FileLogger("log.txt"));

            // Service
            services.AddSingleton<ApiService>();

            // ViewModels
            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegistViewModel>();

            // View
            services.AddSingleton<LoginView>();
            services.AddSingleton<RegistView>();
        }

    }
}
