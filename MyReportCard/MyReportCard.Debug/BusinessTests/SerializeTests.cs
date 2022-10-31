using System;
using System.IO;
using System.Net.Mime;
using System.Security.Permissions;
using System.Text.Json;
using System.Windows.Controls;
using MyReportCard.Business.JsonSerialize;
using MyReportCard.Business.Tools;
using MyReportCard.Data.Models;

namespace MyReportCard.Debug.BusinessTests;

public class SerializeTests
{
    private ISerializable _serializer;
    private DummyUser _user;

    public void SerializeTest(TextBox debugText)
    {
        _serializer = new UserSerializer();
        _user = new DummyUser();
        System.Diagnostics.Debug.Assert(_user.User != null, "_user.User != null");
        _serializer.Serialize(_user.User);
        var unserializedUser = _serializer.Deserialize();
    }
}