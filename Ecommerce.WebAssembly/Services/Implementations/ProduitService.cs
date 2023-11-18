using Ecommerce.DTO;
using Ecommerce.DTO.User;
using Ecommerce.WebAssembly.Services.Contrats;
using System.Data;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementations
{
    public class ProduitService : IProduitService
    {
        private readonly HttpClient _httpClient;
        private const string CONTOLLERNAME = "Produit";
        public ProduitService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ReponseDTO<ProduitDTO>> Add(ProduitDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync($"{CONTOLLERNAME}/add", model);
            var result = await response.Content.ReadFromJsonAsync<ReponseDTO<ProduitDTO>>();

            return result!;
        }

        public async Task<ReponseDTO<List<ProduitDTO>>> Catalogue(string categorie, string chercher)
        {
            return await _httpClient.GetFromJsonAsync<ReponseDTO<List<ProduitDTO>>>($"{CONTOLLERNAME}/catalogue/{categorie.ToLower()}/{chercher.ToLower()}");
        }

        public async Task<ReponseDTO<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ReponseDTO<bool>>($"{CONTOLLERNAME}/delete{id}");
        }

        public async Task<ReponseDTO<ProduitDTO>> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<ReponseDTO<ProduitDTO>>($"{CONTOLLERNAME}/get{id}");
        }

        public async Task<ReponseDTO<List<ProduitDTO>>> List(string chercher)
        {
            return await _httpClient.GetFromJsonAsync<ReponseDTO<List<ProduitDTO>>>($"{CONTOLLERNAME}/list/{chercher.ToLower()}");
        }

        public async Task<ReponseDTO<bool>> Update(ProduitDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync($"{CONTOLLERNAME}/update", model);
            var result = await response.Content.ReadFromJsonAsync<ReponseDTO<bool>>();

            return result!;
        }
    }
}
