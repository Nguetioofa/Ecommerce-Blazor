using Ecommerce.DTO;
using Ecommerce.DTO.User;

namespace Ecommerce.WebAssembly.Services.Contrats
{
    public interface IUtilisateurService
    {
        Task<ReponseDTO<List<UtilisateurDTO>>> List(string role,string recheche);
        Task<ReponseDTO<UtilisateurDTO>> Get(int id);
        Task<ReponseDTO<SessionDTO>> Autorization(LoginDTO model);
        Task<ReponseDTO<UtilisateurDTO>> Add(UtilisateurDTO model);
        Task<ReponseDTO<bool>> Update(LoginDTO model);
        Task<ReponseDTO<bool>> Delete(int id);

    }
}
