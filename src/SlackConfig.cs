using System;

public class SlackConfig
{
    public string ApiEndpoint { get; set; } = "https://slack.com/api";
    public int TimeoutSeconds { get; set; } = 30;
    public int MaxRetries { get; set; } = 3;
    public bool EnableLogging { get; set; } = true;
    public string DefaultChannel { get; set; }

    public SlackConfig()
    {
        ValidateConfig();
    }

    private void ValidateConfig()
    {
        if (TimeoutSeconds <= 0)
            throw new ArgumentException("TimeoutSeconds must be greater than 0");
        if (MaxRetries < 0)
            throw new ArgumentException("MaxRetries cannot be negative");
    }

    public TimeSpan GetTimeout() => TimeSpan.FromSeconds(TimeoutSeconds);
}
