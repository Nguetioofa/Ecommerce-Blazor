using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Contrats;
using System.Net.Http;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementations
{
    public class VenteService : IVenteService
    {
        private readonly HttpClient _httpClient;
        private const string CONTOLLERNAME = "Vente";
        public VenteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ReponseDTO<VenteDTO>> Save(VenteDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync($"{CONTOLLERNAME}/save", model);
            var result = await response.Content.ReadFromJsonAsync<ReponseDTO<VenteDTO>>();

            return result!;
        }
    }
}
