using System;
using System.Collections.Generic;

namespace dapper.Models;

public partial class Employess
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Address { get; set; } = null!;

    public string Department { get; set; } = null!;
}
