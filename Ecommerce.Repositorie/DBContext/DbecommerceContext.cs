using System;
using System.Collections.Generic;
using Ecommerce.Modeles;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositorie.DBContext;

public partial class DbecommerceContext : DbContext
{
    public DbecommerceContext()
    {
    }

    public DbecommerceContext(DbContextOptions<DbecommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorie> Categories { get; set; }

    public virtual DbSet<DetailVente> DetailVentes { get; set; }

    public virtual DbSet<Produit> Produits { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<Vente> Ventes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.HasKey(e => e.IdCategorie).HasName("PK__Categori__A3C02A1C0585C077");

            entity.ToTable("Categorie");

            entity.Property(e => e.DateCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<DetailVente>(entity =>
        {
            entity.HasKey(e => e.IdDetailVente).HasName("PK__DetailVe__44F666A805C134E3");

            entity.ToTable("DetailVente");

            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdProduitNavigation).WithMany(p => p.DetailVentes)
                .HasForeignKey(d => d.IdProduit)
                .HasConstraintName("FK__DetailVen__IdPro__4D94879B");

            entity.HasOne(d => d.IdVenteNavigation).WithMany(p => p.DetailVentes)
                .HasForeignKey(d => d.IdVente)
                .HasConstraintName("FK__DetailVen__IdVen__4CA06362");
        });

        modelBuilder.Entity<Produit>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Produit__2E8946D41AB0E4D4");

            entity.ToTable("Produit");

            entity.Property(e => e.DateCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Prix).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PrixOffre).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCategorieNavigation).WithMany(p => p.Produits)
                .HasForeignKey(d => d.IdCategorie)
                .HasConstraintName("FK__Produit__IdCateg__3A81B327");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.IdUtilisateur).HasName("PK__Utilisat__45A4C1570FA8A609");

            entity.ToTable("Utilisateur");

            entity.Property(e => e.DateCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MotPasse)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NomComplet)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vente>(entity =>
        {
            entity.HasKey(e => e.IdVente).HasName("PK__Vente__BC1240B1D0EC9714");

            entity.ToTable("Vente");

            entity.Property(e => e.DateCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdUtilisateurNavigation).WithMany(p => p.Ventes)
                .HasForeignKey(d => d.IdUtilisateur)
                .HasConstraintName("FK__Vente__IdUtilisa__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
