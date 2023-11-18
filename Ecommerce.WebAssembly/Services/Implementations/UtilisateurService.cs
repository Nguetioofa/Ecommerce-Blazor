using Ecommerce.WebAssembly.Services.Contrats;
using Ecommerce.DTO;
using System.Net.Http.Json;
using Ecommerce.DTO.User;
using System.Reflection;
namespace Ecommerce.WebAssembly.Services.Implementations
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly HttpClient _httpClient;
        private const string CONTOLLERNAME = "Utilisateur";
        public UtilisateurService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ReponseDTO<UtilisateurDTO>> Add(UtilisateurDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync($"{CONTOLLERNAME}/add", model);
            var result = await response.Content.ReadFromJsonAsync<ReponseDTO<UtilisateurDTO>>();

            return result!;
        }

        public async Task<ReponseDTO<SessionDTO>> Autorization(LoginDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync($"{CONTOLLERNAME}/authentification", model);
            var result = await response.Content.ReadFromJsonAsync<ReponseDTO<SessionDTO>>();

            return result!;
        }

        public async Task<ReponseDTO<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ReponseDTO<bool>>($"{CONTOLLERNAME}/delete{id}");

        }

        public async Task<ReponseDTO<UtilisateurDTO>> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<ReponseDTO<UtilisateurDTO>>($"{CONTOLLERNAME}/get{id}");

        }

        public async Task<ReponseDTO<List<UtilisateurDTO>>> List(string role, string recheche)
        {
            return await _httpClient.GetFromJsonAsync<ReponseDTO<List<UtilisateurDTO>>>($"{CONTOLLERNAME}/list/{role.ToLower()}/{recheche.ToLower()}");

        }

        public async Task<ReponseDTO<bool>> Update(LoginDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync($"{CONTOLLERNAME}/update", model);
            var result = await response.Content.ReadFromJsonAsync<ReponseDTO<bool>>();

            return result!;
        }
    }
}
