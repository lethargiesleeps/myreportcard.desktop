using System.Collections.Generic;
using System.Windows.Documents;

namespace MyReportCard.Data.Models;

/// <summary>
///     Course DTO.
/// </summary>
public class Course
{
    public Term? Term { get; set; }
    public char[]? CourseCode { get; set; }
    public string? Name { get; set; }
    public float Gpa { get; set; }
    public bool IsExemptOrWithdrawn { get; set; }
    public char[] LetterGrade { get; set; } = new char[3];
    public int ActivityCount { get; set; }
    public List<Activity> Activities { get; set; } = new();
}