using Ecommerce.DTO.User;
using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Contrats;
using System.Net.Http;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementations
{


    public class CategorieService : ICategorieService
    {
        private readonly HttpClient _httpClient;
        private const string CONTOLLERNAME = "Categorie";
        public CategorieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ReponseDTO<CategorieDTO>> Add(CategorieDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync($"{CONTOLLERNAME}/add", model);
            var result = await response.Content.ReadFromJsonAsync<ReponseDTO<CategorieDTO>>();
            return result!;
        }

        public async Task<ReponseDTO<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ReponseDTO<bool>>($"{CONTOLLERNAME}/delete/{id}");

        }

        public async Task<ReponseDTO<CategorieDTO>> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<ReponseDTO<CategorieDTO>>($"{CONTOLLERNAME}/get/{id}");

        }



        public async Task<ReponseDTO<bool>> Update(CategorieDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync($"{CONTOLLERNAME}/update", model);
            var result = await response.Content.ReadFromJsonAsync<ReponseDTO<bool>>();

            return result!;
        }

        public async Task<ReponseDTO<List<CategorieDTO>>> List(string chercher)
        {
            
           return await _httpClient.GetFromJsonAsync<ReponseDTO<List<CategorieDTO>>>($"{CONTOLLERNAME}/list/{chercher.ToLower()}");
            
        }
    }
}
