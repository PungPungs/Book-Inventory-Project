using StockManagement.Command;
using StockManagement.Service.API;
using StockManagement.Service.Window;
using StockManagement.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StockManagement.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;
        private readonly IWindowService _windowService;

        public LoginViewModel(ApiService apiService, IWindowService windowService)
        {
            _apiService = apiService;
            _windowService = windowService;

            LoginCommand = new RelayCommand(async () => await Login());
            RegistCommand = new RelayCommand(Regist);
        }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand RegistCommand { get; set; }

        private async Task Login()
        {
            bool success = await _apiService.LoginAsync(Email, Password);

            if (success)
            {
                MessageBox.Show("성공");
                MainView mainView = new MainView();
                mainView.Show();
                Application.Current.Windows
                    .OfType<LoginView>()
                    .FirstOrDefault()?.Close();
            }
            else
            {
                MessageBox.Show("실패");
            }
        }

        private void Regist()
        {
            _windowService.ShowWindow<RegistViewModel>();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
