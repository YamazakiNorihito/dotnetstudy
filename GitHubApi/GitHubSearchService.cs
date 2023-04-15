namespace GitHubApi;

public class GitHubSearchService
{
    private static readonly Uri Uri = new("https://api.github.com/search/issues");

    private readonly GitHubClient _gitHubClient;

    public GitHubSearchService(GitHubClient gitHubClient)
        => _gitHubClient = gitHubClient;

    public async Task<List<Item>?> GetReviewRequestedItemsAsync(string account)
    {
        var query = new GitHubSearchQuery
        {
            type = "pr",
            Is = "open",
            ReviewRequested = account
        };
        var root = await _gitHubClient.GetAsync<Root>(new Uri(Uri, $"?q={query.ToQueryString()}"));
        return root?.items;
    }

    public async Task<List<Item>?> GetMentionsItemsAsync(string account)
    {
        var query = new GitHubSearchQuery
        {
            type = "pr",
            Is = "open",
            Mentions = account
        };
        var root = await _gitHubClient.GetAsync<Root>(new Uri(Uri, $"?q={query.ToQueryString()}"));
        return root?.items;
    }
}