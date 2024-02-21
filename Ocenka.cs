using System;
using System.Collections.Generic;

namespace trr;

public partial class Ocenka
{
    public int IdOcenka { get; set; }

    public string Result { get; set; } = null!;

    public int IdPolzovatel { get; set; }

    public DateOnly OcenkaData { get; set; }

    public virtual Polzovatel IdPolzovatelNavigation { get; set; } = null!;
}
