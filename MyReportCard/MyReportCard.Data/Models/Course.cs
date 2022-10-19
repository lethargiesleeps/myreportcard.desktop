namespace MyReportCard.Data.Models;

/// <summary>
/// Course DTO.
/// </summary>
public class Course
{
    public string? CourseCode { get; set; }
    public float Gpa { get; set; }
    public  bool IsExemptOrWithdrawn { get; set; }

}