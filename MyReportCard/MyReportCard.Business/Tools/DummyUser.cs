using System;
using System.Collections.Generic;
using System.Windows.Documents;
using MyReportCard.Business.Builders;
using MyReportCard.Data.Models;

namespace MyReportCard.Business.Tools;

/// <summary>
///     A mock user intended for testing purposes. Construction
/// </summary>
public class DummyUser
{
    public User? User { get; }
    private UserBuilder _userBuilder = null!;
    private TermBuilder _termBuilder = null!;
    private CourseBuilder _courseBuilder = null!;
    private ActivityBuilder _activityBuilder = null!;

    private Activity _activity1 = null!;
    private Activity _activity2 = null!;

    private Course _course1 = null!;
    private Course _course2 = null!;
    private Course _course3 = null!;
    private Course _course4 = null!;

    private Term _term1 = null!;
    private Term _term2 = null!;

    public DummyUser()
    {
        CreateBuilders();
        CreateActivities();
        CreateCourses();
        CreateTerms();
        User = CreateUser();
    }

    /// <summary>
    /// Instantiates builders.
    /// </summary>
    private void CreateBuilders()
    {
        _userBuilder = new UserBuilder();
        _termBuilder = new TermBuilder();
        _courseBuilder = new CourseBuilder();
        _activityBuilder = new ActivityBuilder();
    }

    /// <summary>
    /// Sets values for dummy user.
    /// </summary>
    /// <returns>The dummy user instance;</returns>
    private User? SetUser()
    {
        return _userBuilder.SetName("Michael Landry").SetCreationDate(DateTime.Now).BuildAndGetObject() as User;
    }

    /// <summary>
    /// Instantiates some Activity objects to be added to courses.
    /// <remarks>First method to be used.</remarks>
    /// </summary>
    private void CreateActivities()
    {
        _activity1 = (_activityBuilder.SetName("Midterm")
            .SetDateReceived(new DateTime(2022,06,05))
            .SetDueDate(new DateTime(2022,05,05))
            .SetDescription("Midterm for this class.")
            .SetPointsReceived(45)
            .SetTotalPoints(50)
            .BuildAndGetObject() as Activity)!;

        _activity2 = (_activityBuilder.SetName("Final Exam")
            .SetDescription("The big final!")
            .SetDateReceived(new DateTime(2022, 08, 05))
            .SetDueDate(new DateTime(2022, 08, 05))
            .SetPointsReceived(25)
            .SetTotalPoints(50)
            .BuildAndGetObject() as Activity)!;
    }

    /// <summary>
    /// Instantiates some Course objects to be added to terms.
    /// </summary>
    /// <remarks>Second method be used.</remarks>
    private void CreateCourses()
    {
        _course1 = (_courseBuilder.SetCourseCode("CST1234")
            .SetName("C# Class")
            .SetIsExemptOrWithdrawn(false)
            .SetGpa(4.0f)
            .AddActivity(_activity1)
            .AddActivity(_activity2)
            .BuildAndGetObject() as Course)!;

        _course2 = (_courseBuilder.SetCourseCode("CST4321")
            .SetName("Java Class")
            .SetIsExemptOrWithdrawn(false)
            .SetGpa(3.0f)
            .AddActivity(_activity1)
            .AddActivity(_activity2)
            .BuildAndGetObject() as Course)!;

        _course3 = (_courseBuilder.SetCourseCode("CST6666")
            .SetName("C++ class")
            .SetIsExemptOrWithdrawn(false)
            .SetGpa(2.0f)
            .AddActivity(_activity1)
            .AddActivity(_activity2)
            .BuildAndGetObject() as Course)!;

        _course4 = (_courseBuilder.SetCourseCode("CST9999")
            .SetName("How to use Google")
            .SetIsExemptOrWithdrawn(false)
            .SetGpa(3.0f)
            .AddActivity(_activity1)
            .AddActivity(_activity2)
            .BuildAndGetObject() as Course)!;

    }

    /// <summary>
    /// Instantiates some Term objects.
    /// </summary>
    /// <remarks>3rd Method to be used.</remarks>
    private void CreateTerms()
    {
        _term1 = (_termBuilder.SetTitle("Fall 2022")
            .SetStartDate(DateTime.Now)
            .SetEndDate(DateTime.MaxValue)
            .SetGpa(4.0f)
            .SetDeansHonour(true)
            .AddCourse(_course1)
            .AddCourse(_course2)
            .BuildAndGetObject() as Term)!;

        _term2 = (_termBuilder.SetTitle("Winter 2022")
            .SetStartDate(DateTime.Now)
            .SetEndDate(DateTime.MaxValue)
            .SetGpa(4.0f)
            .SetDeansHonour(true)
            .AddCourse(_course3)
            .AddCourse(_course4)
            .BuildAndGetObject() as Term)!;
    }

    /// <summary>
    /// Creates a user object.
    /// </summary>
    /// <remarks>4th method to be used.</remarks>
    /// <returns>The user object.</returns>
    private User CreateUser()
    {
        return (_userBuilder.SetName("Michael Landry").SetCreationDate(DateTime.Now).AddTerm(_term1).AddTerm(_term2).BuildAndGetObject() as User)!;
    }
}