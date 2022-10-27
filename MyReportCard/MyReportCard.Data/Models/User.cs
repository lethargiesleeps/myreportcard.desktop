using System;
using System.Collections.Generic;

namespace MyReportCard.Data.Models;

/// <summary>
///     User DTO.
/// </summary>
public class User
{
    public string? Name { get; set; }
    public DateTime CreationDate { get; set; }
    public List<Term?> Terms { get; set; } = new();
}