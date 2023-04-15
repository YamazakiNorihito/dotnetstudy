using GitHubApi;

var accounts = new string[]
{
};
var token = "";

var client = new GitHubClient(token);
var service = new GitHubSearchService(client);

foreach (var account in accounts)
{
    var mentionsItems = await service.GetMentionsItemsAsync(account);
    var prItems = await service.GetReviewRequestedItemsAsync(account);

    var dumpTexts = mentionsItems.Union(prItems).ToList()
        .Select(pullReqItem => $"\t{pullReqItem.title}\t|\t{pullReqItem.pull_request.html_url}")
        .Distinct();

    Console.WriteLine(account);
    foreach (var dumpText in dumpTexts)
    {
        Console.WriteLine(dumpText);
    }
}