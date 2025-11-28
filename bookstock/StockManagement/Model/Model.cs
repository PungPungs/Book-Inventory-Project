using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Model
{
    internal class Model
    {
        public class LoginResult
        {
            public string token { get; set; }
            public bool success { get; set; }
        }


        public class Book
        {
            public string title { get; set; }
            public string ISBN { get; set; }
            public string author { get; set; }
        }
    }
}
