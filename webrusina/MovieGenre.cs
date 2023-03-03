using System;
using System.Collections.Generic;

namespace webrusina;

public partial class MovieGenre
{
    public int Movie { get; set; }

    public int Genre { get; set; }

    public virtual Genre GenreNavigation { get; set; } = null!;

    public virtual Movie MovieNavigation { get; set; } = null!;
}
