using System;
using System.Collections.Generic;

namespace ReadCity;

public partial class LoanStatus
{
    public short Id { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();
}
