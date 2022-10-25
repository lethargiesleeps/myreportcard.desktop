using System;
using System.Collections.Generic;

namespace MyReportCard.Data.Models;

/// <summary>
///     Term DTO.
/// </summary>
public class Term
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Title { get; set; }
    public int CourseCount { get; set; }
    public User? User { get; set; }
    public float Gpa { get; set; }
    public bool IsDeansHonour { get; set; }
    public List<Course> Courses { get; set; } = new();
}