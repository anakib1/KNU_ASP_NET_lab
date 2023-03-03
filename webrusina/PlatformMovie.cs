using System;
using System.Collections.Generic;

namespace webrusina;

public partial class PlatformMovie
{
    public int Movie { get; set; }

    public int Platform { get; set; }

    public virtual Movie MovieNavigation { get; set; } = null!;

    public virtual Platform PlatformNavigation { get; set; } = null!;
}
