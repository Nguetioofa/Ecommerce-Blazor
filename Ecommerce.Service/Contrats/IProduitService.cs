using Ecommerce.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Contrats
{
    public interface IProduitService
    {
        Task<List<ProduitDTO>> List(string chercher);
        Task<List<ProduitDTO>> Catalogue(string categorie ,string chercher);
        Task<ProduitDTO> Get(int id);
        Task<ProduitDTO> Add(ProduitDTO model);
        Task<bool> Update(ProduitDTO model);
        Task<bool> Delete(int id);
    }
}
