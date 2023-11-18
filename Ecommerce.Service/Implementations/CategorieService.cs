using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Ecommerce.Modeles;
using Ecommerce.DTO;
using Ecommerce.Repositorie.Contrat;
using Ecommerce.Service.Contrats;
using AutoMapper;
using Ecommerce.DTO.User;
using System.Data;

namespace Ecommerce.Service.Implementations
{
    public class CategorieService : ICategorieService
    {
        private readonly IGenericRepositorie<Categorie> _repositorie;
        private readonly IMapper _mapper;

        public CategorieService(IGenericRepositorie<Categorie> repositorie, IMapper mapper)
        {
            _repositorie = repositorie;
            _mapper = mapper;
        }

        public async Task<CategorieDTO> Add(CategorieDTO model)
        {
            try
            {
                var dbCat = _mapper.Map<Categorie>(model);
                var response = await _repositorie.Add(dbCat);
                if (response.IdCategorie != 0)
                    return _mapper.Map<CategorieDTO>(response);
                else
                    throw new TaskCanceledException("Ajout echouer");
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
                var response = _repositorie.Get(u => u.IdCategorie == id);
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

        public async Task<CategorieDTO> Get(int id)
        {
            try
            {
                var result = _repositorie.Get(u => u.IdCategorie == id);
                var modelDb = await result.FirstOrDefaultAsync();
                if (modelDb != null)
                    return _mapper.Map<CategorieDTO>(modelDb);
                else
                    throw new TaskCanceledException("Categorie introuvable");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<CategorieDTO>> List(string chercher)
        {
            try
            {
                var result = _repositorie.Get(u => u.Nom!.ToLower().Contains(chercher.ToLower()));
                var element = _mapper.Map<List<CategorieDTO>>(await result.ToListAsync());

                return element;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Update(CategorieDTO model)
        {
            try
            {
                var response = _repositorie.Get(u => u.IdCategorie == model.IdCategorie);
                var catBd = await response.FirstOrDefaultAsync();

                if (catBd != null)
                {
                    // userBd = _mapper.Map<Utilisateur>(model);
                    catBd.Nom = model.Nom;


                    var addResponseawait = await _repositorie.Update(catBd);
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
