using System.Text.Json;
using Microsoft.Net.Http.Headers;

namespace GitHubApi;

public class GitHubClient
{
    private static readonly HttpClient _httpClient = new ();
    private readonly string _token;

    private const string MyUserAgent = "MyApp/1.0 (Windows NT 10.0; Win64; x64)";

    public GitHubClient(string token)
    {
        _token = token;
    }

    public async Task<T?> GetAsync<T>(Uri uri)
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri)
        {
            Headers =
            {
                { HeaderNames.Accept, "application/vnd.github.v3+json" },
                { HeaderNames.UserAgent, MyUserAgent },
                { HeaderNames.Authorization, $"Bearer {_token}" }
            }
        };

        using var response = await _httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseContentRead);
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(responseBody);
    }
}