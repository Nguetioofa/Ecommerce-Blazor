using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositorie.Contrat
{
    public interface IGenericRepositorie<TModel> where TModel : class
    {
        IQueryable<TModel> Get(Expression<Func<TModel,bool>>? filtre = null);
        Task<TModel> Creer(TModel model);
        Task<bool> Editer(TModel model);
        Task<bool> Effacer(TModel model);
    }
}
