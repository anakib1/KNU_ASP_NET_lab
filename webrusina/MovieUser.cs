using System;
using System.Collections.Generic;

namespace webrusina;

public partial class MovieUser
{
    public int Movie { get; set; }

    public int User { get; set; }

    public int Rating { get; set; }

    public string Comment { get; set; } = null!;

    public bool Favourite { get; set; }

    public virtual Movie MovieNavigation { get; set; } = null!;

    public virtual User UserNavigation { get; set; } = null!;
}
