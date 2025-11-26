using StockManagement.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Service.Logger
{
    public class FileLogger : ILogger
    {
        private readonly string _logpath;
        
        // 생성자
        public FileLogger(string logpath)
        {
            _logpath = logpath;
        }

        public void Write(string message)
        {
            var text = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {message}\n";
            File.AppendAllText(_logpath, text) ;
        }
    }
}
