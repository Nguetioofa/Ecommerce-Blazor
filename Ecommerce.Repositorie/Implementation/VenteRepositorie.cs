using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.Repositorie.DBContext;
using Ecommerce.Repositorie.Contrat;
using Ecommerce.Modeles;

namespace Ecommerce.Repositorie.Implementation
{
    public class VenteRepositorie : GenericRepositorie<Vente>, IVenteRepositorie
    {
        private readonly DbecommerceContext _dbContext;

        public VenteRepositorie(DbecommerceContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Vente> Save(Vente vente)
        {
            Vente vente1 = new Vente();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var dv in vente.DetailVentes)
                    {
                        Produit produit = _dbContext.Produits.Where(p => p.IdProduct == dv.IdProduit).First();

                        produit.Quantite = produit.Quantite - dv.Quantite;
                        _dbContext.Produits.Update(produit);
                    }

                    await _dbContext.SaveChangesAsync();
                    await _dbContext.Ventes.AddAsync(vente);
                    await _dbContext.SaveChangesAsync();
                    vente1 = vente;
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

            }
            return vente1;
        }
    }
}
