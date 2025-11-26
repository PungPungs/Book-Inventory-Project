using StockManagement.Command;
using StockManagement.Service.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace StockManagement.ViewModel
{
    public class RegistViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;
        public RegistViewModel(ApiService apiService)
        {
            _apiService = apiService;
            DupEmailCommand = new RelayCommand(async() => await DuplicateCheck());
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Checking_Password { get; set; }
        public string Email { get; set; }
        
        public ICommand RegistCommand { get; set; }
        public ICommand DupEmailCommand { get; set; }

        private async Task<bool> DuplicateCheck()
        {
            bool isDuplicate = await _apiService.DuplicateAsync(Email);
            if (isDuplicate)
            {
                TextBox textBox = new TextBox();
                textBox.IsReadOnly = true;

            }
            {
                
            }
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
