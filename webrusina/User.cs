using System;
using System.Collections.Generic;

namespace webrusina;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Country { get; set; }

    public string PhotoUrl { get; set; } = null!;

    public virtual Country CountryNavigation { get; set; } = null!;
}
