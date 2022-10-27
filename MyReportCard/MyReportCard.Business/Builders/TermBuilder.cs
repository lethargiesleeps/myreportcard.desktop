using System;
using System.Collections.Generic;
using MyReportCard.Data.Models;

namespace MyReportCard.Business.Builders;

/// <summary>
///     This class builds a Term object to be serialized.
/// </summary>
public class TermBuilder : IBuildable
{
    private readonly Term _term;

    /// <summary>
    ///     Default constructor, set StartDate to current date,
    /// </summary>
    public TermBuilder()
    {
        _term = new Term
        {
            StartDate = DateTime.Now
        };
    }

    /// <summary>
    ///     Builds and returns the Term.
    /// </summary>
    /// <returns>The term object.</returns>
    public object BuildAndGetObject()
    {
        _term.CourseCount = _term.Courses.Count;
        return _term;
    }


    /// <summary>
    ///     Sets the title of the term.
    /// </summary>
    /// <param name="title">String with title of term.</param>
    /// <returns>The current TermBuilder</returns>
    public TermBuilder SetTitle(string? title)
    {
        _term.Title = title;
        return this;
    }

    /// <summary>
    ///     Sets the end date of the term.
    /// </summary>
    /// <param name="endDate">A Datetime object representing the term's end date.</param>
    /// <returns>The current TermBuilder</returns>
    public TermBuilder SetEndDate(DateTime endDate)
    {
        _term.EndDate = endDate;
        return this;
    }

    /// <summary>
    ///     Sets the start date of the term.
    /// </summary>
    /// <param name="startDate">A DateTime object representing the term's start date.</param>
    /// <returns>The current TermBuilder</returns>
    public TermBuilder SetStartDate(DateTime startDate)
    {
        _term.StartDate = startDate;
        return this;
    }

    /// <summary>
    ///     Sets the term's GPA.
    /// </summary>
    /// <param name="gpa">GPA value</param>
    /// <returns>The current TermBuilder></returns>
    public TermBuilder SetGpa(float gpa)
    {
        if (gpa > 4.0f)
            gpa = 4.0f;
        if (gpa < 0.0f)
            gpa = 0.0f;

        _term.Gpa = gpa;
        return this;
    }

    /// <summary>
    ///     Sets whether or not the term made the Dean's Honour List.
    /// </summary>
    /// <param name="deansHonour">Term's dean's honour value.</param>
    /// <returns>The current TermBuilder</returns>
    public TermBuilder SetDeansHonour(bool deansHonour)
    {
        _term.IsDeansHonour = deansHonour;
        return this;
    }

    /// <summary>
    ///     Sets the term's courses list.
    /// </summary>
    /// <param name="courses">A List of courses</param>
    /// <returns>The current TermBuilder</returns>
    /// <exception cref="ArgumentNullException">Throws if list is null.</exception>
    public TermBuilder SetCourses(List<Course> courses)
    {
        if (courses is null || courses.Count <= 0) throw new ArgumentNullException(nameof(courses));
        _term.Courses = courses;
        return this;
    }

    /// <summary>
    ///     Sets the term's courses list.
    /// </summary>
    /// <param name="courses">An array of courses</param>
    /// <returns>The current TermBuilder</returns>
    /// <exception cref="ArgumentNullException">Throws if array is null.</exception>
    public TermBuilder SetCourses(Course[] courses)
    {
        if (courses is null || courses.Length <= 0) throw new ArgumentNullException(nameof(courses));
        _term.Courses = new List<Course>();
        foreach (var course in courses)
            _term.Courses.Add(course);
        return this;
    }

    /// <summary>
    ///     Adds a course to the courses list.
    /// </summary>
    /// <param name="course">A course object.</param>
    /// <returns>The current TermBuilder</returns>
    /// <exception cref="ArgumentNullException">Throws if Course is null.</exception>
    public TermBuilder AddCourse(Course course)
    {
        if (course is null) throw new ArgumentNullException(nameof(course));
        _term.Courses ??= new List<Course>();
        _term.Courses.Add(course);
        return this;
    }
}