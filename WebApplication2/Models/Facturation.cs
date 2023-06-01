using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gestpsfe.Models;

public partial class Facturation
{
    public int Id { get; set; }
   
    public DateTime DateFacturation { get; set; }

    public decimal Montant { get; set; }

    public string Description { get; set; } = null!;

    public int AgenceId { get; set; }
    [JsonIgnore]
    public virtual Agence ?Agence { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Facturation()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}
