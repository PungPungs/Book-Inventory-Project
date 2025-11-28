using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Service.Window
{
    // Services/.cs
    public interface IWindowService
    {
        void ShowWindow<TViewModel>() where TViewModel : class;
        void ShowDialog<TViewModel>() where TViewModel : class;
        void CloseWindow<TViewModel>() where TViewModel : class;
    }
}
