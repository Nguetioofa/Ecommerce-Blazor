using Ecommerce.WebAssembly.Services.Contrats;
using Blazored.LocalStorage;
using Blazored.Toast;
using Ecommerce.DTO;
using Blazored.Toast.Services;

namespace Ecommerce.WebAssembly.Services.Implementations
{
    public class PanierService : IPanierService
    {
        private ILocalStorageService _localStorageService;
        private ISyncLocalStorageService _syncLocalStorageService;
        private IToastService _toastService;

        public PanierService(ILocalStorageService localStorageService, ISyncLocalStorageService syncLocalStorageService,
                                IToastService toastService)
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService;
            _toastService = toastService;
        }

        public event Action NombresElements;

        public async Task AjouterPanier(PanierDTO model)
        {
            try
            {
                var panier = await _localStorageService.GetItemAsync<List<PanierDTO>>("panier");
                if (panier == null)
                    panier = new List<PanierDTO>();

                var elemnt = panier.FirstOrDefault(p=>p.produit.IdProduct == model.produit.IdProduct);

                if (elemnt != null)
                    panier.Remove(elemnt);

                panier.Add(model);
                await _localStorageService.SetItemAsync("panier", panier);

                if (elemnt != null)
                    _toastService.ShowSuccess("Produit mise a jours dans le panier");
                else
                    _toastService.ShowSuccess(message: "Produit ajouter dans le panier");

                NombresElements.Invoke();

            }
            catch
            {

                _toastService.ShowError(message: "Impossible lw dans  le panier");
            }
        }

        public async Task EffacerPanier()
        {
            await _localStorageService.RemoveItemAsync("panier");
            NombresElements.Invoke();

        }

        public async Task<List<PanierDTO>> PanierList()
        {
            var panier = await _localStorageService.GetItemAsync<List<PanierDTO>>("panier");
            if(panier == null)
                return  new List<PanierDTO>();

            return panier;
        }

        public int QunatiteProduits()
        {
            var panier = _syncLocalStorageService.GetItem<List<PanierDTO>>("panier");

            return panier == null ? 0 : panier.Count;
        }

        public async Task SupprimerProduitPanier(int idProduit)
        {
            try
            {
                var panier = await _localStorageService.GetItemAsync<List<PanierDTO>>("panier");
                if (panier != null)
                {
                    var element = panier.FirstOrDefault(p => p.produit.IdProduct == idProduit);
                    if (element != null)
                    {
                        panier.Remove(element);
                        await _localStorageService.SetItemAsync("panier", panier);
                        NombresElements.Invoke();
                    }
                }
            }
            catch
            {

            }
        }
    }
}
