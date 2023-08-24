using Ecommerce.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositorie.Contrat
{
    public interface IVenteRepositorie : IGenericRepositorie<Vente>
    {
        Task<Vente> Enregister(Vente vente);
    }
}
