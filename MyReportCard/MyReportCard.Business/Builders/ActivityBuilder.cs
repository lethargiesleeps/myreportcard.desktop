using System;
using MyReportCard.Business.Tools;
using MyReportCard.Data.Models;
using MyReportCard.Data.Tools;

namespace MyReportCard.Business.Builders;

/// <summary>
///     This class builds an Activity object to be serialized.
/// </summary>
public class ActivityBuilder : IBuildable
{
    private readonly Activity _activity;

    /// <summary>
    ///     Default constructor.
    /// </summary>
    public ActivityBuilder()
    {
        _activity = new Activity();
    }

    /// <summary>
    ///     Builds and returns the Activity.
    /// </summary>
    /// <returns>The Activity object.</returns>
    public object BuildAndGetObject()
    {
        return _activity;
    }

    /// <summary>
    ///     Sets the name of the Activity.
    /// </summary>
    /// <param name="name">A string representation of the name.</param>
    /// <returns>The current ActivityBuilder object.</returns>
    public ActivityBuilder SetName(string name)
    {
        _activity.Name = name;
        return this;
    }

    /// <summary>
    ///     Sets the description of the Activity.
    /// </summary>
    /// <param name="description">A string representation of the description.</param>
    /// <returns>The current ActivityBuilder.</returns>
    public ActivityBuilder SetDescription(string description)
    {
        _activity.Description = description;
        return this;
    }

    /// <summary>
    ///     Sets the date the Activity is due.
    /// </summary>
    /// <param name="date">A DateTime instance.</param>
    /// <returns>The current ActivityBuilder.</returns>
    public ActivityBuilder SetDueDate(DateTime? date)
    {
        _activity.DueDate = date;
        return this;
    }

    /// <summary>
    ///     Sets the date the Activity was received.
    /// </summary>
    /// <param name="date">A DateTime instance.</param>
    /// <returns>The current ActivityBuilder.</returns>
    public ActivityBuilder SetDateReceived(DateTime? date)
    {
        _activity.DateReceived = date;
        return this;
    }

    /// <summary>
    ///     Sets the point's received for the activity.
    /// </summary>
    /// <param name="pointsReceived">Points received value.</param>
    /// <returns>The current ActivityBuilder.</returns>
    public ActivityBuilder SetPointsReceived(float pointsReceived)
    {
        _activity.PointsReceived = pointsReceived < 0.0f ? 0.0f : pointsReceived;
        return this;
    }

    /// <summary>
    ///     Sets the total points for the activity.
    /// </summary>
    /// <param name="totalPoints">Total points value.</param>
    /// <returns>The current ActivityBuilder.</returns>
    public ActivityBuilder SetTotalPoints(float totalPoints)
    {
        _activity.TotalPoints = totalPoints < _activity.PointsReceived ? _activity.PointsReceived : totalPoints;
        return this;
    }

    /// <summary>
    ///     Sets the Activity's letter grade value using a string.
    /// </summary>
    /// <param name="letterGrade">The string representation of the letter grade.</param>
    /// <returns>The current ActivityBuilder.</returns>
    /// <exception cref="ArgumentNullException">Throws if letterGrade argument is empty.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Throw if length of string is less than/equal to 0 or greater than 3.</exception>
    public ActivityBuilder SetLetterGrade(string letterGrade)
    {
        if (string.IsNullOrEmpty(letterGrade)) throw new ArgumentNullException(nameof(letterGrade));
        if (letterGrade.Length > 3 || letterGrade.Length <= 0)
            throw new ArgumentOutOfRangeException(nameof(letterGrade),
                "Length of letter grade must be between 1 and 3.");
        _activity.LetterGrade ??= new char[3];
        for (var i = 0; i < letterGrade.Length; i++)
            _activity.LetterGrade[i] = letterGrade[i];
        return this;
    }

    /// <summary>
    ///     Sets the Activity's letter grade using an array of characters.
    /// </summary>
    /// <param name="letterGrade">Character array representing the letter grade.</param>
    /// <returns>The current ActivityBuilder.</returns>
    /// <exception cref="ArgumentNullException">Throws if letterGrade argument is empty.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Throw if length of array is not between 1 and 3.</exception>
    public ActivityBuilder SetLetterGrade(char[] letterGrade)
    {
        if (letterGrade is null) throw new ArgumentNullException(nameof(letterGrade));
        if (letterGrade.Length > 3 || letterGrade.Length <= 0)
            throw new ArgumentOutOfRangeException(nameof(letterGrade),
                "letterGrade must contain between 1 and 3 values.");
        _activity.LetterGrade ??= new char[3];
        for (var i = 0; i < letterGrade.Length; i++)
            if (char.IsLetterOrDigit(letterGrade[i]))
                _activity.LetterGrade[i] = letterGrade[i];

        return this;
    }

    /// <summary>
    ///     Uses the LetterGrade enum to set the Activity's letter grade value.
    /// </summary>
    /// <param name="letterGrade">Letter grade chosen from enum.</param>
    /// <see cref="LetterGradeGenerator">Uses static class LetterGradeGenerator.</see>
    /// <returns>The current ActivityBuilder.</returns>
    public ActivityBuilder SetLetterGrade(LetterGrade letterGrade)
    {
        _activity.LetterGrade = LetterGradeGenerator.GenerateLetterGrade(letterGrade);
        return this;
    }

    /// <summary>
    ///     Sets the global percentage of the Activity.
    /// </summary>
    /// <param name="percentage">Percentage value.</param>
    /// <returns>The current ActivityBuilder.</returns>
    public ActivityBuilder SetPercentage(float percentage)
    {
        _activity.Percentage = percentage < 0.0f ? 0.0f : percentage;
        return this;
    }
}