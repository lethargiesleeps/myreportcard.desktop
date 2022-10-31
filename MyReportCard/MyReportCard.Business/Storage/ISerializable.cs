using MyReportCard.Data.Models;

namespace MyReportCard.Business.Storage;

public interface ISerializable
{
    void Serialize(User user);
    User? Deserialize(string json);
}