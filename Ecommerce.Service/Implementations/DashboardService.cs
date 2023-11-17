using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Modeles;
using Ecommerce.Repositorie.Contrat;
using Ecommerce.Service.Contrats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly IGenericRepositorie<Produit> _produitRepositorie;
        private readonly IGenericRepositorie<Utilisateur> _utilisateurRepositorie;
        private readonly IVenteRepositorie _venteRepositorie;

        public DashboardService(
            IGenericRepositorie<Produit> produitRepositorie,
            IGenericRepositorie<Utilisateur> utilisateurRepositorie,
            IVenteRepositorie venteRepositorie
        )
        {
            _produitRepositorie = produitRepositorie;
            _utilisateurRepositorie = utilisateurRepositorie;
            _venteRepositorie = venteRepositorie;
        }

        private string ChiffreDAffaire()
        {
            var element = _venteRepositorie.Get();
            var recette = element.Sum(x => x.Total);
            return recette.ToString();
        }

        private int TotalVentes()
        {
            var element = _venteRepositorie.Get();
            return element.Count();
        }

        private int TotalClients()
        {
            var element = _utilisateurRepositorie.Get(u=>u.Role.ToLower() == "client");
            return element.Count();
        }

        private int TotalProduits()
        {
            var element = _produitRepositorie.Get();
            return element.Count();
        }

        public DashboardDTO Resume()
        {
            try
            {
                DashboardDTO dashboardDTO = new()
                {
                    TotalClient = TotalClients(),
                    TotalProduit = TotalProduits(),
                    ChiffreDAffaire = ChiffreDAffaire(),
                    TotalVente = TotalVentes(),
                };
                return dashboardDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
