using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using MyReportCard.Business.Builders;
using MyReportCard.Data.Models;

namespace MyReportCard.Debug.BusinessTests;

/// <summary>
///     This test unit tests all classes that implement IBuildable.
///     <see cref="IBuildable" />
/// </summary>
public class BuilderTestUnit
{
    private readonly TermBuilder _termBuilder = new();
    private readonly UserBuilder _userBuilder = new();
    private Term? _term;
    private User? _user;

    /// <summary>
    ///     Tests building a user object without any terms.
    /// </summary>
    /// <remarks>Test Successful</remarks>
    /// <param name="output">The TextBox element to display output</param>
    public void UserBuilderNoTermTest(TextBox output)
    {
        _user = _userBuilder.SetName("Michael").SetCreationDate(DateTime.Now).BuildAndGetObject() as User;
        output.Text = $"NAME: {_user!.Name}\nDATE: {_user.CreationDate.ToShortDateString()}";
    }

    /// <summary>
    ///     Tests building a user object without any terms.
    /// </summary>
    /// <remarks>Test Successful</remarks>
    /// <param name="output">The TextBox element to display output.</param>
    public void UserBuilderWithTerms(TextBox output)
    {
        _user = _userBuilder.SetName("Michael").SetCreationDate(DateTime.Now).AddTerm(
            new Term
            {
                User = _user!,
                CourseCount = 55,
                EndDate = new DateTime(2023, 11, 5),
                Gpa = 4.0f
            }).BuildAndGetObject() as User;
        output.Text = $"NAME: {_user!.Name}\n" +
                      $"DATE: {_user.CreationDate.ToShortDateString()}\n" +
                      "==============================\n" +
                      "TERM INFO:\n" +
                      $"COURSE COUNT: {_user.Terms[0]!.CourseCount}\n" +
                      $"END DATE: {_user.Terms[0]!.EndDate.ToShortDateString()}\n" +
                      $"GPA: {_user.Terms[0]!.Gpa}";
    }

    /// <summary>
    ///     Tests building a Term object without any courses.
    /// </summary>
    /// <remarks>Test Successful</remarks>
    /// <param name="output">The TextBox element to display output.</param>
    public void TermBuilderNoCourseTest(TextBox output)
    {
        _term = _termBuilder.SetTitle("Fall 2023").SetDeansHonour(true).SetStartDate(DateTime.Now)
            .SetEndDate(DateTime.MaxValue).SetGpa(4.0f).BuildAndGetObject() as Term;
        output.Text = $"TERM TITLE: {_term!.Title}\n" +
                      $"GPA: {_term.Gpa}\n" +
                      $"DEAN'S HONOUR: {_term.IsDeansHonour}" +
                      $"START DATE: {_term.StartDate}\n" +
                      $"END DATE: {_term.EndDate}\n";
    }

    /// <summary>
    ///     Tests building a Term object with courses.
    /// </summary>
    /// <remarks>Test Passed: 10/25/2022</remarks>
    /// <param name="output">The TextBox element to display output.</param>
    public void TermBuilderWithCoursesTest(TextBox output)
    {
        _term = _termBuilder.SetStartDate(DateTime.Now).SetEndDate(DateTime.MaxValue).SetGpa(5f)
            .SetTitle("Summer").SetCourses(new List<Course>
            {
                new()
                {
                    CourseCode = "CST1234".ToCharArray(),
                    Gpa = 4.0f,
                    IsExemptOrWithdrawn = false
                },
                new()
                {
                    CourseCode = "CST4321".ToCharArray(),
                    Gpa = 4f,
                    IsExemptOrWithdrawn = false
                }
            }).BuildAndGetObject() as Term;
        output.Text = $"TERM NAME: {_term!.Title}\n" +
                      $"START DATE/END DATE: {_term.StartDate}/{_term.EndDate}\n" +
                      $"GPA: {_term.Gpa}\n" +
                      "============\n";
        foreach (var termCourse in _term.Courses)
            output.Text += $"COURSE CODE: {termCourse.CourseCode}\n" +
                           $"GPA: {termCourse.Gpa}\n" +
                           $"DEAN's HONOUR?: {termCourse.IsExemptOrWithdrawn}";
    }

    /// <summary>
    ///     Tests adding a term, populating terms for a User, setting user in term, and removing a Term.
    /// </summary>
    /// <remarks>Test Passed.</remarks>
    /// <param name="output">The TextBox element to display output.</param>
    public void ComplexTermBuilderTest(TextBox output)
    {
        _term = _termBuilder.SetTitle("Spring").SetGpa(2.5f).BuildAndGetObject() as Term;
        _user = _userBuilder.SetName("Michael Landry").SetCreationDate(DateTime.Now)
            .SetTerms(new List<Term?>
            {
                new TermBuilder().SetTitle("Summer").SetGpa(5).BuildAndGetObject() as Term,
                new TermBuilder().SetTitle("Fall").SetGpa(2.3f).BuildAndGetObject() as Term,
                new TermBuilder().SetTitle("Winter").SetGpa(3.4f).BuildAndGetObject() as Term
            }).AddTerm(_term).BuildAndGetObject() as User;
        foreach (var userTerm in _user!.Terms) userTerm!.User = _user;
        var sb = new StringBuilder();
        sb.Append($"USER: {_user.Name}\n========================");
        foreach (var userTerm in _user.Terms)
            sb.Append($"TERM NAME: {userTerm!.Title}\nGPA: {userTerm.Gpa}\nUSER: {userTerm.User!.Name}");

        output.Text = sb.ToString();
        try
        {
            _user.Terms.Remove(_term);
        }
        catch
        {
            throw new Exception("Term was not removed.");
        }

        if (_user.Terms.Count <= 3)
            output.Text += $"TERM REMOVED: {_term!.Title}";
    }
}