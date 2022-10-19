using System;
using System.Windows.Controls;
using MyReportCard.Business.Builders;
using MyReportCard.Data.Models;

namespace MyReportCard.Debug.BusinessTests;
/// <summary>
/// This test unit tests all classes that implement IBuildable.
/// <see cref="IBuildable"/>
/// </summary>
public class BuilderTestUnit
{
    private User? _user;
    private readonly UserBuilder _userBuilder = new();

    /// <summary>
    /// Tests building a user object without any terms.
    /// </summary>
    /// <remarks>Test Successful</remarks>
    /// <param name="output">The TextBox element to display output</param>
    public void UserBuilderNoTermTest(TextBox output)
    {
        _user = _userBuilder.SetName("Michael").SetCreationDate(DateTime.Now).BuildAndGetObject() as User;
        output.Text = $"NAME: {_user.Name}\nDATE: {_user.CreationDate.ToShortDateString()}";
    }
    /// <summary>
    /// Tests building a user object without any terms.
    /// </summary>
    /// <remarks>Test Successful</remarks>
    /// <param name="output">The TextBox element to display output</param>
    public void UserBuilderWithTerms(TextBox output)
    {
        _user = _userBuilder.SetName("Michael").SetCreationDate(DateTime.Now).AddTerm(
            new Term()
            {
                User = _user!,
                CourseCount = 55,
                EndDate = new DateTime(2023, 11, 5),
                Gpa = 4.0f
            }).BuildAndGetObject() as User;
        output.Text = $"NAME: {_user!.Name}\n" +
                      $"DATE: {_user.CreationDate.ToShortDateString()}\n" +
                      $"==============================\n" +
                      $"TERM INFO:\n" +
                      $"COURSE COUNT: {_user.Terms[0].CourseCount}\n" +
                      $"END DATE: {_user.Terms[0].EndDate.ToShortDateString()}\n" +
                      $"GPA: {_user.Terms[0].Gpa}";
    }
}