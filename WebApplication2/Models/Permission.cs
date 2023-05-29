using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gestpsfe.Models;

public partial class Permission
{
    public int Id { get; set; }

    public int Create { get; set; }

    public int Update { get; set; }

    public int Delete { get; set; }

    public int Consulte { get; set; }

    public virtual ICollection<User>? Users { get; set; } 
}
