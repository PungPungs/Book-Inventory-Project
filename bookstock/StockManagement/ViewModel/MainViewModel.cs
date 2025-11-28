using StockManagement.Service.API;
using StockManagement.Service.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;
        private readonly IWindowService _windowService;

        public MainViewModel(ApiService apiService, IWindowService windowService)
        {
            _apiService = apiService;
            _windowService = windowService;
        }

        public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged([CallerMemberName] string name = null)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
