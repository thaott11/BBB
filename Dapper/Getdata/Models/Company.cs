using System;
using System.Collections.Generic;

namespace Getdata.Models;

public partial class Company
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string? Name { get; set; }

    public string? Address { get; set; }
}
