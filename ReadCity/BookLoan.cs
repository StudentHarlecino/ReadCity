using System;
using System.Collections.Generic;

namespace ReadCity;

public partial class BookLoan
{
    public int Id { get; set; }

    public int LibraryCard { get; set; }

    public int IsbnBook { get; set; }

    public DateOnly DateOfIssue { get; set; }

    public DateOnly PlannedReturnDate { get; set; }

    public DateOnly? ActualReturnDate { get; set; }

    public short StatusId { get; set; }

    public virtual Book IsbnBookNavigation { get; set; } = null!;

    public virtual User LibraryCardNavigation { get; set; } = null!;

    public virtual LoanStatus Status { get; set; } = null!;
}
