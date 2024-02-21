using System;
using System.Collections.Generic;

namespace trr;

public partial class Polzovatel
{
    public int IdPolzovatel { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public DateOnly DataRogd { get; set; }

    public int IdAvtorizaciya { get; set; }

    public int IdClass { get; set; }

    public virtual Avtorizaciya IdAvtorizaciyaNavigation { get; set; } = null!;

    public virtual Class IdClassNavigation { get; set; } = null!;

    public virtual ICollection<Ocenka> Ocenkas { get; set; } = new List<Ocenka>();
}
