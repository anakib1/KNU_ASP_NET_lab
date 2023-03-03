using System;
using System.Collections.Generic;

namespace webrusina;

public partial class Staff
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Bio { get; set; } = null!;

    public string PhotoUrl { get; set; } = null!;

    public int Oskars { get; set; }

    public string Role { get; set; } = null!;
}
