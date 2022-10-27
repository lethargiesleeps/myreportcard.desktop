using System;

namespace MyReportCard.Data.Models;

public class Activity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? DateReceived { get; set; }
    public float PointsReceived { get; set; }
    public float TotalPoints { get; set; }
    public char[] LetterGrade { get; set; } = new char[3];
    public float Percentage { get; set; }
    
}