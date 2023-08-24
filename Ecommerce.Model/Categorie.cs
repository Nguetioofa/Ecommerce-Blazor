using System;
using System.Collections.Generic;

namespace Ecommerce.Modeles;

public partial class Categorie
{
    public int IdCategorie { get; set; }

    public string? Nom { get; set; }

    public DateTime? DateCreation { get; set; }

    public virtual ICollection<Produit> Produits { get; set; } = new List<Produit>();
}
