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
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IGenericRepositorie<Utilisateur> _repositorie;
        private readonly IMapper _mapper;

        public UtilisateurService(IGenericRepositorie<Utilisateur> repositorie, IMapper mapper)
        {
            _repositorie = repositorie;
            _mapper = mapper;
        }

        public async Task<UtilisateurDTO> Add(UtilisateurDTO model)
        {
            try
            {
                var dbUser = _mapper.Map<Utilisateur>(model);
                var response = await _repositorie.Add(dbUser);
                if (response.IdUtilisateur != 0) 
                    return _mapper.Map<UtilisateurDTO>(response);
                else
                    throw  new TaskCanceledException("Ajout echouer");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<SessionDTO> Autorization(LoginDTO model)
        {
            try
            {
                var user = _repositorie.Get(u => u.Email == model.Email && u.MotPasse == model.MotPasse);
                var userDb = await user.FirstOrDefaultAsync();
                if (userDb != null)
                    return _mapper.Map<SessionDTO>(userDb);
                else
                    throw new TaskCanceledException("pas de correspondance");
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
                var response = _repositorie.Get(u => u.IdUtilisateur == id);
                var userBd = await response.FirstOrDefaultAsync();
                if (userBd != null)
                {
                   var responseDelete = await _repositorie.Delete(userBd);
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

        public async Task<UtilisateurDTO> Get(int id)
        {
            try
            {
                var result = _repositorie.Get(u => u.IdUtilisateur == id);
                var modelDb = await result.FirstOrDefaultAsync();
                if (modelDb != null)
                    return _mapper.Map<UtilisateurDTO>(modelDb);
                else
                    throw new TaskCanceledException("Utilisateur introuvable");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<UtilisateurDTO>> List(string role, string chercher)
        {
            try
            {
                var result = _repositorie.Get(u => u.Role == role
                                                && string.Concat(u.Email.ToLower(), u.NomComplet.ToLower()).Contains(chercher.ToLower()));
               var users = _mapper.Map<List<UtilisateurDTO>>(await result.ToListAsync());

                return users;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Update(UtilisateurDTO model)
        {
            try
            {
                var response = _repositorie.Get(u=>u.IdUtilisateur == model.IdUtilisateur);
                var userBd = await response.FirstOrDefaultAsync();

                if (userBd != null)
                {
                   // userBd = _mapper.Map<Utilisateur>(model);
                    userBd.NomComplet = model.NomComplet;
                    userBd.MotPasse = model.MotPasse;
                    userBd.Email = model.Email;

                    var addResponseawait = await _repositorie.Update(userBd);
                    if (!addResponseawait)
                         throw new TaskCanceledException("modifiaction echouer");
                    
                    return addResponseawait;
                }
                else
                    throw new TaskCanceledException("Auccun utilisateur trouver");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
