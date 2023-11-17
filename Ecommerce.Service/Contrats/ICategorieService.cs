using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.DTO;
using Ecommerce.DTO.User;

namespace Ecommerce.Service.Contrats
{
    public interface ICategorieService
    {
        Task<List<CategorieDTO>> List(string chercher);
        Task<CategorieDTO> Get(int id);
        Task<CategorieDTO> Add(CategorieDTO model);
        Task<bool> Update(CategorieDTO model);
        Task<bool> Delete(int id);
    }
}
