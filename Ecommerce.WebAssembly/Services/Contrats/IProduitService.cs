using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contrats
{
    public interface IProduitService
    {
        Task<ReponseDTO<List<ProduitDTO>>> List(string chercher);
        Task<ReponseDTO<List<ProduitDTO>>> Catalogue(string categorie, string chercher);
        Task<ReponseDTO<ProduitDTO>> Get(int id);
        Task<ReponseDTO<ProduitDTO>> Add(ProduitDTO model);
        Task<ReponseDTO<bool>> Update(ProduitDTO model);
        Task<ReponseDTO<bool>> Delete(int id);
    }
}
