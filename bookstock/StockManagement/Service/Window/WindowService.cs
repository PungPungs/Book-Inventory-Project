// Services/WindowService.cs
using System;
using System.Linq;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using StockManagement.Service.Window;
using StockManagement.View;
using StockManagement.ViewModel;

public class WindowService : IWindowService
{
    private readonly IServiceProvider _serviceProvider;

    public WindowService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void ShowWindow<TViewModel>() where TViewModel : class
    {
        var viewModel = _serviceProvider.GetRequiredService<TViewModel>();
        var window = CreateWindow(viewModel);
        window.Show();
    }

    public void ShowDialog<TViewModel>() where TViewModel : class
    {
        var viewModel = _serviceProvider.GetRequiredService<TViewModel>();
        var window = CreateWindow(viewModel);
        window.ShowDialog();
    }

    public void CloseWindow<TViewModel>() where TViewModel : class
    {
        var window = Application.Current.Windows
            .OfType<Window>()
            .FirstOrDefault(w => w.DataContext is TViewModel);

        window?.Close();
    }

    private Window CreateWindow(object viewModel)
    {
        Window window = null;
        var viewModelType = viewModel.GetType();


        if (viewModelType == typeof(RegistViewModel))
        {
            window = new RegistView();
        }
        else if (viewModelType == typeof(LoginViewModel))
        {
            window = new LoginView();
        }
        else
        {
            throw new ArgumentException($"No view registered for {viewModelType.Name}");
        }

        window.DataContext = viewModel;
        return window;
    }
}