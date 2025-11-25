using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Service.Logger
{ 
    public interface ILogger
    {
        void Write(string message);
    }
}
