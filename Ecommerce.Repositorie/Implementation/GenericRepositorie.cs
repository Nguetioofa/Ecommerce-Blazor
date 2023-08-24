using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.Repositorie.DBContext;
using Ecommerce.Repositorie.Contrat;
using System.Linq.Expressions;

namespace Ecommerce.Repositorie.Implementation
{
    public class GenericRepositorie<TModel> : IGenericRepositorie<TModel> where TModel : class
    {
        private readonly DbecommerceContext _dbContext;

        public GenericRepositorie(DbecommerceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TModel> Creer(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> Editer(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Effacer(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<TModel> Get(Expression<Func<TModel, bool>>? filtre = null)
        {
            IQueryable<TModel> liste = (filtre == null) ? _dbContext.Set<TModel>() : _dbContext.Set<TModel>().Where(filtre);
                return liste;
        }
    }
}
