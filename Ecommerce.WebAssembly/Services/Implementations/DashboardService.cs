using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Contrats;
using System.Net.Http;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly HttpClient _httpClient;
        private const string CONTOLLERNAME = "Dashboard";
        public DashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<ReponseDTO<DashboardDTO>> Resume()
        {
            return await _httpClient.GetFromJsonAsync<ReponseDTO<DashboardDTO>>($"{CONTOLLERNAME}/resume");
        }
    }
}
