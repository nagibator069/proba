using System;
using System.Collections.Generic;

namespace trr;

public partial class Avtorizaciya
{
    public int IdAvtorizaciya { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Polzovatel> Polzovatels { get; set; } = new List<Polzovatel>();
}
