using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contrats
{
    public interface IPanierService
    {
        event Action NombresElements;
        int QunatiteProduits();
        Task AjouterPanier(PanierDTO model);
        Task SupprimerProduitPanier(int idProduit);
        Task<List<PanierDTO>> PanierList();
        Task EffacerPanier();
    }
}
