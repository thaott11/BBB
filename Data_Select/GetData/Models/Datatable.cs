using System;
using System.Collections.Generic;

namespace GetData.Models;

public partial class Datatable
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public string? DataSelect { get; set; }

    public string? OrderBy { get; set; }
}
