using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Gestpsfe.Models;

public partial class PfeContext : DbContext
{
   

    public PfeContext(DbContextOptions<PfeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agence> Agences { get; set; }

    public virtual DbSet<Circuit> Circuits { get; set; }

    public virtual DbSet<Cotisation> Cotisations { get; set; }

    public virtual DbSet<Facturation> Facturations { get; set; }

    public virtual DbSet<ListePlanification> ListePlanifications { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PlanificationParAgence> PlanificationParAgences { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicule> Vehicules { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuration pour rendre l'attribut Matricule unique dans le modèle Agence
        modelBuilder.Entity<Agence>()
            .HasIndex(a => a.Matricule)
            .IsUnique();

        // Configuration pour rendre l'attribut Email unique dans le modèle User
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Matricule)
            .IsUnique();

        modelBuilder.Entity<User>()
          .HasIndex(u => u.Email)
          .IsUnique();
        // Configuration pour rendre l'attribut Immatricule unique dans le modèle User
        modelBuilder.Entity<Vehicule>()
            .HasIndex(u => u.Immatricule)
            .IsUnique();


    }

}
