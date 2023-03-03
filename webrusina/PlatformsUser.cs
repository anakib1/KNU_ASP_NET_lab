using System;
using System.Collections.Generic;

namespace webrusina;

public partial class PlatformsUser
{
    public int Platform { get; set; }

    public int User { get; set; }

    public DateTime SubscribedUntil { get; set; }

    public virtual Platform PlatformNavigation { get; set; } = null!;

    public virtual User UserNavigation { get; set; } = null!;
}
