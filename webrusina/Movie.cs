using System;
using System.Collections.Generic;

namespace webrusina;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime RelaseDate { get; set; }

    public int Duration { get; set; }

    public double AverageCriticRating { get; set; }

    public double AverageUserRating { get; set; }
}
