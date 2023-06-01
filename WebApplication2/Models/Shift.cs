using System;
using System.Collections.Generic;

namespace Gestpsfe.Models;

public partial class Shift
{
    public int Id { get; set; }

    public DateTime Entre { get; set; }

    public DateTime Sortie { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<User> ?Users { get; set; } = new List<User>();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Shift()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}
