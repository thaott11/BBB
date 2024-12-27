using System;
using System.Collections.Generic;

namespace Getdata.Models;

public partial class Employess
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string? NameEmploy { get; set; }

    public int? Age { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }
}
