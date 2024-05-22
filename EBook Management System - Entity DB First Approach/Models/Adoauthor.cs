using System;
using System.Collections.Generic;

namespace EBook_Management_System___Entity_DB_First_Approach.Models;

public partial class Adoauthor
{
    public Guid AuthorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? Biography { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Country { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Adobook> Books { get; set; } = new List<Adobook>();
}
