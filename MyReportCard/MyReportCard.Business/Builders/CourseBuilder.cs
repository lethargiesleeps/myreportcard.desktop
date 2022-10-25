using System;
using System.Collections.Generic;
using MyReportCard.Business.Tools;
using MyReportCard.Data.Models;
using MyReportCard.Data.Tools;

namespace MyReportCard.Business.Builders;

/// <summary>
///     This class builds a Course object to be serialized.
/// </summary>
public class CourseBuilder : IBuildable
{
    private readonly Course _course;

    /// <summary>
    ///     Default constructor.
    /// </summary>
    public CourseBuilder()
    {
        _course = new Course();
    }

    /// <summary>
    ///     Builds and returns the Course.
    /// </summary>
    /// <returns>The Course object.</returns>
    public object BuildAndGetObject()
    {
        _course.ActivityCount = _course.Activities.Count;
        if(_course.ActivityCount > 0)
            foreach(var a in _course.Activities)
                a.Course = _course;
        return _course;
    }

    /// <summary>
    ///     Sets the Course Code for the Course object using a string.
    /// </summary>
    /// <param name="courseCode">Course Code as string</param>
    /// <returns>The current CourseBuilder.</returns>
    /// <exception cref="ArgumentNullException">Throws if empty string is passed.</exception>
    public CourseBuilder SetCourseCode(string courseCode)
    {
        if (string.IsNullOrEmpty(courseCode)) throw new ArgumentNullException(nameof(courseCode));

        _course.CourseCode = new char[courseCode.Length];
        for (var i = 0; i < courseCode.Length; i++)
            _course.CourseCode[i] = courseCode[i];

        return this;
    }

    /// <summary>
    ///     Sets the Code for the Course object using an array of characters.
    /// </summary>
    /// <param name="courseCode">The characters representing the Course Code</param>
    /// <returns>The current CourseBuilder object.</returns>
    /// <exception cref="ArgumentNullException">Throws if courseCode is null.</exception>
    public CourseBuilder SetCourseCode(char[] courseCode)
    {
        if (courseCode is null) throw new ArgumentNullException(nameof(courseCode));
        _course.CourseCode ??= new char[courseCode.Length];
        _course.CourseCode = courseCode;
        return this;
    }

    /// <summary>
    ///     Sets the full name of the course.
    /// </summary>
    /// <param name="name">The course name as a string.</param>
    /// <returns>The current CourseBuilder object.</returns>
    public CourseBuilder SetName(string name)
    {
        _course.Name = name;
        return this;
    }

    /// <summary>
    ///     Sets the Course GPA
    /// </summary>
    /// <param name="gpa"></param>
    /// <returns></returns>
    public CourseBuilder SetGpa(float gpa)
    {
        if (gpa > 4.0f)
            gpa = 4.0f;
        if (gpa < 0.0f)
            gpa = 0.0f;

        _course.Gpa = gpa;
        return this;
    }

    /// <summary>
    ///     Sets the value of IsExemptOrWithdrawn
    /// </summary>
    /// <param name="isExemptOrWithdrawn">The value of whether or not a course is exempted or withdrawn.</param>
    /// <returns>The current CourseBuilder object.</returns>
    public CourseBuilder SetIsExemptOrWithdrawn(bool isExemptOrWithdrawn)
    {
        _course.IsExemptOrWithdrawn = isExemptOrWithdrawn;
        return this;
    }

    /// <summary>
    ///     Sets the Course's letter grade value using a string.
    /// </summary>
    /// <param name="letterGrade">The string representation of the letter grade.</param>
    /// <returns>The current CourseBuilder object.</returns>
    /// <exception cref="ArgumentNullException">Throws if letterGrade argument is empty.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Throw if length of string is less than/equal to 0 or greater than 3</exception>
    public CourseBuilder SetLetterGrade(string letterGrade)
    {
        if (string.IsNullOrEmpty(letterGrade)) throw new ArgumentNullException(nameof(letterGrade));
        if (letterGrade.Length > 3 || letterGrade.Length <= 0)
            throw new ArgumentOutOfRangeException(nameof(letterGrade),
                "Length of letter grade must be between 1 and 3.");
        _course.LetterGrade ??= new char[3];
        for (var i = 0; i < letterGrade.Length; i++)
            _course.LetterGrade[i] = letterGrade[i];
        return this;
    }

    /// <summary>
    ///     Sets the Course's letter grade using an array of characters.
    /// </summary>
    /// <param name="letterGrade">Character array representing the letter grades.</param>
    /// <returns>The current CourseBuilder object.</returns>
    /// <exception cref="ArgumentNullException">Throws if letterGrade argument is empty.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Throw if length of array is less than/equal to 0 or greater than 3</exception>
    public CourseBuilder SetLetterGrade(char[] letterGrade)
    {
        if (letterGrade is null) throw new ArgumentNullException(nameof(letterGrade));
        if (letterGrade.Length == 0 || letterGrade.Length > 3)
            throw new ArgumentOutOfRangeException(nameof(letterGrade),
                "letterGrade must contain between 1 and 3 values.");
        _course.LetterGrade ??= new char[3];
        for (var i = 0; i < letterGrade.Length; i++)
            if (char.IsLetterOrDigit(letterGrade[i]))
                _course.LetterGrade[i] = letterGrade[i];

        return this;
    }

    /// <summary>
    ///     Uses the LetterGrade enum to set the Course's letter grade value.
    /// </summary>
    /// <param name="letterGrade">Letter grade chosen from enum.</param>
    /// <see cref="LetterGradeGenerator">Uses static class LetterGradeGenerator.</see>
    /// <returns>The current CourseBuilder.</returns>
    public CourseBuilder SetLetterGrade(LetterGrade letterGrade)
    {
        _course.LetterGrade = LetterGradeGenerator.GenerateLetterGrade(letterGrade);
        return this;
    }

    /// <summary>
    ///     Sets the Courses activities list.
    /// </summary>
    /// <param name="activities">A list of Activity objects.</param>
    /// <returns>The current CourseBuilder object.</returns>
    /// <exception cref="ArgumentNullException">Throws if list provided is null.</exception>
    public CourseBuilder SetActivities(List<Activity> activities)
    {
        if (activities is null || activities.Count <= 0) throw new ArgumentNullException(nameof(activities));
        _course.Activities = activities;
        return this;
    }

    /// <summary>
    ///     Sets the Course's activities list using an array.
    /// </summary>
    /// <param name="activities">An array of Activity objects.</param>
    /// <returns>The current CourseBuilder object.</returns>
    /// <exception cref="ArgumentNullException">Throws if the array provided is nul.</exception>
    public CourseBuilder SetActivities(Activity[] activities)
    {
        if (activities is null || activities.Length <= 0) throw new ArgumentNullException(nameof(activities));
        _course.Activities = new List<Activity>();
        foreach (var activity in activities)
            _course.Activities.Add(activity);
        return this;
    }

    /// <summary>
    ///     Adds an activity to the Activities list.
    /// </summary>
    /// <param name="activity">An activity object.</param>
    /// <returns>The current CourseBuilder object.</returns>
    /// <exception cref="ArgumentNullException">Throws if the activity argument is null.</exception>
    public CourseBuilder AddActivity(Activity activity)
    {
        if (activity is null) throw new ArgumentNullException(nameof(activity));
        _course.Activities ??= new List<Activity>();
        _course.Activities.Add(activity);
        return this;
    }

    /// <summary>
    ///     Sets the Course's Term instance.
    /// </summary>
    /// <param name="term">An instance of Term.</param>
    /// <returns>The current CourseBuilder object.</returns>
    /// <exception cref="ArgumentNullException">Throws if Term is null.</exception>
    public CourseBuilder SetTerm(Term term)
    {
        _course.Term = term ?? throw new ArgumentNullException(nameof(term));
        return this;
    }

    /// <summary>
    ///     Sets the Course's Term instance using a TermBuilder.
    /// </summary>
    /// <param name="termBuilder">The term builder being used.</param>
    /// <returns>The current CourseBuilder object.</returns>
    /// <exception cref="ArgumentNullException">Throws if termBuilder is null.</exception>
    public CourseBuilder SetTerm(TermBuilder termBuilder)
    {
        _course.Term = termBuilder.BuildAndGetObject() as Term ??
                       throw new ArgumentNullException(nameof(termBuilder));
        return this;
    }
}