using System;
using System.Collections.Generic;

namespace ReadCity;

public partial class User
{
    public int Id { get; set; }

    public short IdRole { get; set; }

    public string FullName { get; set; } = null!;

    public string LibraryCard { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
