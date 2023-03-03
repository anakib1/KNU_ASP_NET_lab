using System;
using System.Collections.Generic;

namespace webrusina;

public partial class PlatformCountry
{
    public int Price { get; set; }

    public int Platform { get; set; }

    public int Country { get; set; }

    public virtual Country CountryNavigation { get; set; } = null!;

    public virtual Platform PlatformNavigation { get; set; } = null!;
}
