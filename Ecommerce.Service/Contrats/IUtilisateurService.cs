using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTO;
using Ecommerce.DTO.User;

namespace Ecommerce.Service.Contrats
{
    public interface IUtilisateurService
    {
        Task<List<UtilisateurDTO>> List(string role, string chercher);
        Task<UtilisateurDTO> Get(int id);
        Task<SessionDTO> Autorization(LoginDTO model);
        Task<UtilisateurDTO> Add(UtilisateurDTO model);
        Task<bool> Update(UtilisateurDTO model);
        Task<bool> Delete(int id);

    }
}
