using System;
using System.Collections.Generic;

namespace EBook_Management_System___Entity_DB_First_Approach.Models;

public partial class Adobook
{
    public Guid BookId { get; set; }

    public string Title { get; set; } = null!;

    public string? Descriptions { get; set; }

    public Guid Isbn { get; set; }

    public DateTime? PublicationDate { get; set; }

    public double? Price { get; set; }

    public string? BookLanguage { get; set; }

    public string? Publisher { get; set; }

    public int? PagesCount { get; set; }

    public double? AvgRating { get; set; }

    public int? BookGenre { get; set; }

    public bool? IsAvailable { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Genre? BookGenreNavigation { get; set; }

    public virtual ICollection<Adoauthor> Authors { get; set; } = new List<Adoauthor>();
}
