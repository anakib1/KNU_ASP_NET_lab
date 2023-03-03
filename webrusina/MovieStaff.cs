using System;
using System.Collections.Generic;

namespace webrusina;

public partial class MovieStaff
{
    public int StaffMember { get; set; }

    public int Movie { get; set; }

    public virtual Movie MovieNavigation { get; set; } = null!;

    public virtual Staff StaffMemberNavigation { get; set; } = null!;
}
