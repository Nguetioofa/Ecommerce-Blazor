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
        Task<TModel> Add(TModel model);
        Task<bool> Update(TModel model);
        Task<bool> Delete(TModel model);
    }
}
