using App1.Data;
using System;

namespace App1.Models;
public partial class AppLogModel
{
    //public static AppLogModel CreateEmpty() => new() { Id = -1, IsEmpty = true };

    public int Id
    {
        get; set;
    }

    public bool IsRead
    {
        get; set;
    }

    public DateTimeOffset DateTime
    {
        get; set;
    }

    public string User
    {
        get; set;
    }

    public LogType Type
    {
        get; set;
    }
    public string Source
    {
        get; set;
    }
    public string Action
    {
        get; set;
    }
    public string Message
    {
        get; set;
    }
    public string Description
    {
        get; set;
    }
}
