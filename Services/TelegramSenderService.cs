using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace TelegramSender.Services;

public class TelegramSenderService
{
    private readonly HttpClient _httpClient;
    private readonly string _botToken;
    private readonly string _chatId;

    public TelegramSenderService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _botToken = config["Telegram:BotToken"]
            ?? throw new InvalidOperationException("Telegram:BotToken не задан");
        _chatId = config["Telegram:ChatId"]
            ?? throw new InvalidOperationException("Telegram:ChatId не задан");
    }

    public async Task<string> SendMessageAsync(string text)
    {
        var url = $"https://api.telegram.org/bot{_botToken}/sendMessage";

        var payload = new
        {
            chat_id = _chatId,
            text = text
        };

        var response = await _httpClient.PostAsJsonAsync(url, payload);
        var body = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException($"Telegram error: {body}");
        }

        return body;
    }
}
