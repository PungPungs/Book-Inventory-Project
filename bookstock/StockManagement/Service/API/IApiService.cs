using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Service.API
{
    public interface IApiService
    {
        Task<bool> LoginAsync(string email, string password);
    }
}
