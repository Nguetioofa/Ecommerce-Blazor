using System;
using System.Collections.Generic;

namespace Ecommerce.Modeles;

public partial class DetailVente
{
    public int IdDetailVente { get; set; }

    public int? IdVente { get; set; }

    public int? IdProduit { get; set; }

    public int? Quantite { get; set; }

    public decimal? Total { get; set; }

    public virtual Produit? IdProduitNavigation { get; set; }

    public virtual Vente? IdVenteNavigation { get; set; }
}
