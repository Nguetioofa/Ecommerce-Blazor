using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.DTO.User;
using Ecommerce.Modeles;


namespace Ecommerce.Utilitaires
{
    public class AutoMapperProfil : Profile
    {
        public AutoMapperProfil()
        {
            CreateMap<Utilisateur,UtilisateurDTO>();
            CreateMap<Utilisateur,SessionDTO>();
            CreateMap<UtilisateurDTO,Utilisateur>();

            CreateMap<Categorie, CategorieDTO>();
            CreateMap<CategorieDTO, Categorie>();

            CreateMap<Produit, ProduitDTO>();
            CreateMap<ProduitDTO, Produit>().ForMember(destina =>
            destina.IdCategorieNavigation,
            opt => opt.Ignore());

            CreateMap<DetailVente, DetailVenteDTO>();
            CreateMap<DetailVenteDTO, DetailVente>();

            CreateMap<Vente, VenteDTO>();
            CreateMap<VenteDTO, Vente>();
        }
    }
}
