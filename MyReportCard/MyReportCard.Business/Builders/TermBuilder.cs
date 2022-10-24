using System;
using System.Collections.Generic;
using System.Windows.Media.TextFormatting;
using MyReportCard.Data.Models;

namespace MyReportCard.Business.Builders;

public class TermBuilder : IBuildable
{
    private readonly Term _term;

    public TermBuilder()
    {
        _term = new Term()
        {
            StartDate = DateTime.Now
        };
    }

    public TermBuilder SetTitle(string? title)
    {
        _term.Title = title;
        return this;
    }

    public TermBuilder SetEndDate(DateTime endDate)
    {
        _term.EndDate = endDate;
        return this;
    }

    public TermBuilder SetUser(User user)
    {
        _term.User = user;
        return this;
    }

    public TermBuilder SetCourseCount(int courseCount)
    {
        _term.CourseCount = courseCount;
        return this;
    }

    public TermBuilder SetGpa(float gpa)
    {
        _term.Gpa = gpa;
        return this;
    }

    public TermBuilder SetDeansHonour(bool deansHonour)
    {
        _term.IsDeansHonour = deansHonour;
        return this;
    }

    public TermBuilder SetCourses(List<Course> courses)
    {
        if (courses is null || courses.Count <= 0) throw new ArgumentNullException(nameof(courses));
        _term.Courses = new List<Course>();
        return this;
    }

    public TermBuilder SetCourses(Course[] courses)
    {
        if (courses is null || courses.Length <= 0) throw new ArgumentNullException(nameof(courses));
        _term.Courses = new List<Course>();
        foreach (var course in courses)
            _term.Courses.Add(course);
        return this;
    }

    public TermBuilder AddCourse(Course course)
    {
        if(course is null) throw new ArgumentNullException(nameof(course));
        _term.Courses ??= new List<Course>();
        _term.Courses.Add(course);
        return this;
    }

    public TermBuilder RemoveCourse(Course course)
    {
        if (course is null) throw new ArgumentNullException(nameof(course));
        _term.Courses ??= new List<Course>();
        _term.Courses.Remove(course);
        return this;
    }


    public object BuildAndGetObject() => (Term) _term;

}