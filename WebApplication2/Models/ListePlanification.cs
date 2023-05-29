using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gestpsfe.Models;

public partial class ListePlanification
{
    public int Id { get; set; }

    public string PlanificationName { get; set; } = null!;

    public DateTime Entre { get; set; }

    public DateTime Sortie { get; set; }

    public DateTime Repos { get; set; }

    public virtual ICollection<User> ? Users { get; set; }  =new Collection<User>();
}
