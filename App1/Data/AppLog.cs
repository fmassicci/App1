using System;

namespace App1.Data;
public enum LogType
{
    Information,
    Warning,
    Error
}

public class AppLog
{
    public int Id
    {
        get; set;
    }
    public string Action
    {
        get; set;
    }
    public DateTimeOffset DateTime
    {
        get; set;
    }
    public string Description
    {
        get; set;
    }
    public bool IsRead
    {
        get; set;
    }
    public string Message
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }
    public string Source
    {
        get; set;
    }
    public LogType Type
    {
        get; set;
    }
    public string User
    {
        get; set;
    }
