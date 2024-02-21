using System;
using System.Collections.Generic;

namespace trr;

public partial class Student
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public string Class { get; set; } = null!;

    public long Number { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }
}
