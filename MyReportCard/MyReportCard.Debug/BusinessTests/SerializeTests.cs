using System;
using System.IO;
using System.Net.Mime;
using System.Security.Permissions;
using System.Text.Json;
using System.Windows.Controls;
using MyReportCard.Business.JsonSerialize;
using MyReportCard.Business.Tools;

namespace MyReportCard.Debug.BusinessTests;

public class SerializeTests
{
    private ISerializable _serializer;
    private DummyUser _user;

    public void SerializeTest(TextBox debugText)
    {
        
        _user = new DummyUser();
        JsonSerializerOptions options = new JsonSerializerOptions();
        var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\data.json";
        options.WriteIndented = true;
        var json = JsonSerializer.Serialize(_user.User, options);
        File.WriteAllText(path, json);
        
        debugText.Text = path + json.ToString();

    }
}