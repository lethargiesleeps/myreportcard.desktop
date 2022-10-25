namespace MyReportCard.Business.Builders;

/// <summary>
///     Interface for buildable objects. Must be type-cast to object that implements it.
///     <example>_user.BuildAndGetObject() as User;</example>
/// </summary>
public interface IBuildable
{
    object BuildAndGetObject();
}