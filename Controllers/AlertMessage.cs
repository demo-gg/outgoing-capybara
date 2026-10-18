using System;
using System.Collections.Generic;

public class AlertMessage
{
    public string ChannelId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public AlertSeverity Severity { get; set; }
    public Dictionary<string, string> Metadata { get; set; }
    public DateTime CreatedAt { get; set; }

    public AlertMessage()
    {
        Metadata = new Dictionary<string, string>();
        CreatedAt = DateTime.UtcNow;
    }

    public string FormatMessage()
    {
        var color = Severity switch
        {
            AlertSeverity.Critical => "danger",
            AlertSeverity.Warning => "warning",
            _ => "good"
        };
        return $"[{Severity}] {Title}: {Description}";
    }
}

public enum AlertSeverity
{
    Info,
    Warning,
    Critical
}
