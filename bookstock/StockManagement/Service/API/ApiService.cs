using StockManagement.Service.Logger;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static StockManagement.Model.Model;

namespace StockManagement.Service.API
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        private readonly string _baseUrl = "http://localhost:3000/";

        public ApiService(ILogger logger)
        {
            _logger = logger;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };

        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var payload = new
            {
                email = email,
                password = password,
            };
            

            string jsonData = JsonSerializer.Serialize(payload);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var url = new Uri(_httpClient.BaseAddress, "rpc/login");

            try
            {
                _logger.Write("로그인 요청 시작");
                var response = await _httpClient.PostAsync(url, content);
                string body = await response.Content.ReadAsStringAsync();
                _logger.Write($"응답 본문: {body}");
                if (!response.IsSuccessStatusCode) {return false;}
                _logger.Write("로그인 요청 성공");
                var responseJson = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<LoginResult>(responseJson);
                _logger.Write($"로그인 여부 : {result.success}");
                return result?.success ?? false;
            }
            catch (Exception e) {
                _logger.Write($"로그인 실패 {e.ToString()}");
                return false;
            }

        }

    }
}
