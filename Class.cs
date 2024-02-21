using System;
using System.Collections.Generic;

namespace trr;

public partial class Class
{
    public int IdClass { get; set; }

    public int NomerClassa { get; set; }

    public string BykvaClassa { get; set; } = null!;

    public virtual ICollection<Polzovatel> Polzovatels { get; set; } = new List<Polzovatel>();
}
