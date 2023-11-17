
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Modeles;
using Ecommerce.Repositorie.Contrat;
using Ecommerce.Service.Contrats;

namespace Ecommerce.Service.Implementations
{
    public class ProduitService : IProduitService
    {
        private readonly IGenericRepositorie<Produit> _repositorie;
        private readonly IMapper _mapper;

        public ProduitService(IGenericRepositorie<Produit> repositorie, IMapper mapper)
        {
            _repositorie = repositorie;
            _mapper = mapper;
        }

        public async Task<ProduitDTO> Add(ProduitDTO model)
        {
            try
            {
                var dbProd = _mapper.Map<Produit>(model);
                var response = await _repositorie.Add(dbProd);
                if (response.IdCategorie != 0)
                    return _mapper.Map<ProduitDTO>(response);
                else
                    throw new TaskCanceledException("Ajout echouer");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ProduitDTO>> Catalogue(string categorie, string chercher)
        {
            try
            {
                var result = _repositorie.Get(u => string.Concat(u.Nom.ToLower(), u.Description.ToLower()).Contains(chercher.ToLower())
                                                               && u.IdCategorieNavigation.Nom.ToLower().Contains(categorie.ToLower()));
                
                var element = _mapper.Map<List<ProduitDTO>>(await result.ToListAsync());

                return element;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var response = _repositorie.Get(u => u.IdProduct == id);
                var elementBd = await response.FirstOrDefaultAsync();
                if (elementBd != null)
                {
                    var responseDelete = await _repositorie.Delete(elementBd);
                    if (!responseDelete)
                        throw new TaskCanceledException("Suppression echouer");
                    else
                    {
                        return responseDelete;
                    }
                }
                else
                {
                    throw new TaskCanceledException("Auccun element a supprimer trouver");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ProduitDTO> Get(int id)
        {
            try
            {
                var result = _repositorie.Get(u => u.IdProduct == id);
                result = result.Include(c => c.IdCategorieNavigation);

                var modelDb = await result.FirstOrDefaultAsync();
                if (modelDb != null)
                    return _mapper.Map<ProduitDTO>(modelDb);
                else
                    throw new TaskCanceledException("Produit  introuvable");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ProduitDTO>> List(string chercher)
        {
            try
            {
                var result = _repositorie.Get(u => string.Concat(u.Nom.ToLower(),u.Description.ToLower()).Contains(chercher.ToLower()));

                result = result.Include(c => c.IdCategorieNavigation);

                var element = _mapper.Map<List<ProduitDTO>>(await result.ToListAsync());

                
                return element;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Update(ProduitDTO model)
        {
            try
            {
                var response = _repositorie.Get(u => u.IdProduct == model.IdProduct);
                var prodBd = await response.FirstOrDefaultAsync();

                if (prodBd != null)
                {
                    prodBd.Nom = model.Nom;
                    prodBd.Image = model.Image;
                    prodBd.Description = model.Description;
                    prodBd.Quantite  = model.Quantite;
                    prodBd.Prix = model.Prix;
                    prodBd.PrixOffre = model.PrixOffre;
                    prodBd.IdCategorie = model.IdCategorie;


                    var addResponseawait = await _repositorie.Update(prodBd);
                    if (!addResponseawait)
                        throw new TaskCanceledException("modifiaction echouer");

                    return addResponseawait;
                }
                else
                    throw new TaskCanceledException("Auccun Element trouver");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
