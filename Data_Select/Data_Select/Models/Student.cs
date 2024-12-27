using System;
using System.Collections.Generic;

namespace Data_Select.Models;

public partial class Student
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Address { get; set; }
}
