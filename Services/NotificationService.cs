using System;
using System.Net.Http;
using System.Threading.Tasks;

public class NotificationService
{
    private readonly SlackNotifier _slackNotifier;
    private readonly SlackConfig _config;

    public NotificationService(SlackConfig config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
        var httpClient = new HttpClient { Timeout = config.GetTimeout() };
        _slackNotifier = new SlackNotifier(httpClient);
    }

    public async Task NotifyAsync(AlertMessage alert)
    {
        if (string.IsNullOrEmpty(alert.ChannelId))
            alert.ChannelId = _config.DefaultChannel;

        if (_config.EnableLogging)
            Console.WriteLine($"Sending notification: {alert.Title}");

        await _slackNotifier.SendAlertAsync(alert.ChannelId, alert.FormatMessage());
    }
}
