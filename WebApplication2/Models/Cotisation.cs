using System;
using System.Collections.Generic;

namespace Gestpsfe.Models;

public partial class Cotisation
{
    public int Id { get; set; }

    public DateTime Mois { get; set; }

    public double Montant { get; set; }

    public int UserId { get; set; }

    public virtual User ?User { get; set; } 
}
