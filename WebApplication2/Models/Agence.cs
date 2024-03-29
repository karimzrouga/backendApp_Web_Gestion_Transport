﻿
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Gestpsfe.Models;

public partial class Agence
{
    public int Id { get; set; }
  
    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string RaisonSocial { get; set; } = null!;

    public string Matricule { get; set; } = null!;
  

    public virtual ICollection<Facturation> ?Facturations { get; set; } = new List<Facturation>();
    [JsonIgnore]
    public virtual ICollection<Vehicule> ?Vehicules { get; set; } = new List<Vehicule>();

    public virtual ICollection<PlanificationParAgence> ? PlanificationParAgences { get; set; } = new List<PlanificationParAgence>();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Agence()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}
