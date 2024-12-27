using System;
using System.Collections.Generic;

namespace Data_Select.Models;

public partial class DataSelect
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? SelectFile { get; set; }

    public string? OrderByFile { get; set; }
}
