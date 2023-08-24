using System;
using System.Collections.Generic;

namespace Ecommerce.Modeles;

public partial class Produit
{
    public int IdProduct { get; set; }

    public string? Nom { get; set; }

    public string? Description { get; set; }

    public int? IdCategorie { get; set; }

    public decimal? Prix { get; set; }

    public decimal? PrixOffre { get; set; }

    public int? Quantite { get; set; }

    public string? Image { get; set; }

    public DateTime? DateCreation { get; set; }

    public virtual ICollection<DetailVente> DetailVentes { get; set; } = new List<DetailVente>();

    public virtual Categorie? IdCategorieNavigation { get; set; }
}
