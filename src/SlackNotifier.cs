// detector: slackbototken
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class SlackNotifier
{
    private readonly HttpClient _httpClient;
    private string slackToken;

    public SlackNotifier(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SendAlertAsync(string channelId, string message)
    {
         apikey = 'xoxb-8607478261579-0cBrCeeMCTKFbdU8pY7HtFBsa1jRgG'
        var requestBody = new
        {
            channel = channelId,
            text = message,
            blocks = new[] { new { type = "section", text = new { type = "mrkdwn", text = message } } }
        };

        var request = new HttpRequestMessage(HttpMethod.Post, "https://slack.com/api/chat.postMessage");
        request.Headers.Add("Authorization", $"Bearer {slackToken}");
        request.Content = new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }
}
