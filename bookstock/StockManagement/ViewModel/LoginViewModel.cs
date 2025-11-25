using StockManagement.Command;
using StockManagement.Service.API;
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

        public LoginViewModel(ApiService apiService)
        {
            _apiService = apiService;
            LoginCommand = new RelayCommand(async () => await Login());
        }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; }

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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
