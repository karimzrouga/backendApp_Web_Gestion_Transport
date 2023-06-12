using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gestpsfe.Models;

public partial class Cotisation
{
    public int Id { get; set; }
  
    public DateTime Mois { get; set; }

    public double Montant { get; set; }

    public int UserId { get; set; }
  
    public virtual User ?User { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Cotisation()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}
