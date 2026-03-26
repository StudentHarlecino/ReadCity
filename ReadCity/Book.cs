using System;
using System.Collections.Generic;

namespace ReadCity;

public partial class Book
{
    public int Id { get; set; }

    public string Isbn { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string PublishingHouse { get; set; } = null!;

    public short YearOfPublication { get; set; }

    public short Pages { get; set; }

    public short Total { get; set; }

    public short Available { get; set; }

    public string Annotation { get; set; } = null!;

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();
}
