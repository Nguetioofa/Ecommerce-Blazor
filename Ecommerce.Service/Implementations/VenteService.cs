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
    public class VenteService : IVenteService
    {
        private readonly IVenteRepositorie _repositorie;
        private readonly IMapper _mapper;

        public VenteService(IVenteRepositorie repositorie, IMapper mapper)
        {
            _repositorie = repositorie;
            _mapper = mapper;
        }

        public async Task<VenteDTO> Save(VenteDTO model)
        {
            try
            {
                var dbVente = _mapper.Map<Vente>(model);
                var response = await _repositorie.Save(dbVente);
                if (response.IdVente != 0)
                    return _mapper.Map<VenteDTO>(response);
                else
                    throw new TaskCanceledException("Ajout echouer");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
