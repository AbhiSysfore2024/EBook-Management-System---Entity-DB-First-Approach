using System;
using System.Collections.Generic;

namespace EBook_Management_System___Entity_DB_First_Approach.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string? GenreName { get; set; }

    public virtual ICollection<Adobook> Adobooks { get; set; } = new List<Adobook>();
}
