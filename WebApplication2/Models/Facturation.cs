using System;
using System.Collections.Generic;

namespace Gestpsfe.Models;

public partial class Facturation
{
    public int Id { get; set; }

    public DateTime DateFacturation { get; set; }

    public decimal Montant { get; set; }

    public string Description { get; set; } = null!;

    public int AgenceId { get; set; }

    public virtual Agence Agence { get; set; } = null!;
}
