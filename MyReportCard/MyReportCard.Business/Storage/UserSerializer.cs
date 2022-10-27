﻿using System.IO;
using MyReportCard.Data.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace MyReportCard.Business.JsonSerialize;

public class UserSerializer : ISerializable
{
    private string _path = "./DATA.json";

    public void Serialize(User user)
    {
        var json = JsonSerializer.Serialize(user);
        
    }

    public User? Deserialize()
    {
        var json = File.ReadAllText(_path);
        return JsonSerializer.Deserialize<User>(json);
    }
}