using MyReportCard.Data.Models;

namespace MyReportCard.Business.JsonSerialize;

public interface ISerializable
{
    void Serialize(User user);
    User? Deserialize();
}