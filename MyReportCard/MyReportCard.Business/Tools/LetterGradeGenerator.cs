using System.ComponentModel;
using System.Text;
using MyReportCard.Data.Tools;

namespace MyReportCard.Business.Tools;

/// <summary>
///     This static singleton's sole purpose is to return the appropriate letter grade.
/// </summary>
public static class LetterGradeGenerator
{
    /// <summary>
    ///     Returns string in letter grade format based on an enum.
    /// </summary>
    /// <param name="letterGrade">The letter grade enum argument.</param>
    /// <returns>The letter grade.</returns>
    /// <exception cref="InvalidEnumArgumentException">Throws when an inappropriate enum is passed.</exception>
    public static char[] GenerateLetterGrade(LetterGrade letterGrade)
    {
        var sb = new StringBuilder();
        switch (letterGrade)
        {
            case LetterGrade.APlusPlus:
                sb.Append("A++");
                break;
            case LetterGrade.APlus:
                sb.Append("A+");
                break;
            case LetterGrade.A:
                sb.Append('A');
                break;
            case LetterGrade.AMinus:
                sb.Append("A-");
                break;
            case LetterGrade.BPlus:
                sb.Append("B+");
                break;
            case LetterGrade.B:
                sb.Append('B');
                break;
            case LetterGrade.BMinus:
                sb.Append("B-");
                break;
            case LetterGrade.CPlus:
                sb.Append("C+");
                break;
            case LetterGrade.C:
                sb.Append('C');
                break;
            case LetterGrade.CMinus:
                sb.Append("C-");
                break;
            case LetterGrade.DPlus:
                sb.Append("D+");
                break;
            case LetterGrade.D:
                sb.Append('D');
                break;
            case LetterGrade.DMinus:
                sb.Append("D-");
                break;
            case LetterGrade.F:
                sb.Append("F");
                break;
            case LetterGrade.Ex:
                sb.Append("Exempt");
                break;
            case LetterGrade.W:
                sb.Append("Withdrew");
                break;
            default:
                throw new InvalidEnumArgumentException(
                    $"Passed an invalid argument of type {letterGrade.GetType().FullName}");
        }

        return sb.ToString().ToCharArray();
    }
}