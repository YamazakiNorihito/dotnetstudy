﻿using System.Text.Json.Serialization;

namespace GitHubApi;

public class Root
{
    public int total_count { get; set; }
    public bool incomplete_results { get; set; }
    public List<Item> items { get; set; }
}

public class Item
{
    public string url { get; set; }
    public string repository_url { get; set; }
    public string labels_url { get; set; }
    public string comments_url { get; set; }
    public string events_url { get; set; }
    public string html_url { get; set; }
    public int id { get; set; }
    public string node_id { get; set; }
    public int number { get; set; }
    public string title { get; set; }
    public User user { get; set; }
    public List<Label> labels { get; set; }
    public string state { get; set; }
    public bool locked { get; set; }
    public object assignee { get; set; }
    public List<object> assignees { get; set; }
    public object milestone { get; set; }
    public int comments { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public object closed_at { get; set; }
    public string author_association { get; set; }
    public object active_lock_reason { get; set; }
    public bool draft { get; set; }
    public PullRequest pull_request { get; set; }
    public string body { get; set; }
    public Reactions reactions { get; set; }
    public string timeline_url { get; set; }
    public object performed_via_github_app { get; set; }
    public object state_reason { get; set; }
    public double score { get; set; }
}

public class Label
{
    public object id { get; set; }
    public string node_id { get; set; }
    public string url { get; set; }
    public string name { get; set; }
    public string color { get; set; }
    public bool @default { get; set; }
    public string description { get; set; }
}

public class PullRequest
{
    public string url { get; set; }
    public string html_url { get; set; }
    public string diff_url { get; set; }
    public string patch_url { get; set; }
    public object merged_at { get; set; }
}

public class Reactions
{
    public string url { get; set; }
    public int total_count { get; set; }

    [JsonPropertyName("+1")] public int good { get; set; }

    [JsonPropertyName("-1")] public int bad { get; set; }
    public int laugh { get; set; }
    public int hooray { get; set; }
    public int confused { get; set; }
    public int heart { get; set; }
    public int rocket { get; set; }
    public int eyes { get; set; }
}

public class User
{
    public string login { get; set; }
    public int id { get; set; }
    public string node_id { get; set; }
    public string avatar_url { get; set; }
    public string gravatar_id { get; set; }
    public string url { get; set; }
    public string html_url { get; set; }
    public string followers_url { get; set; }
    public string following_url { get; set; }
    public string gists_url { get; set; }
    public string starred_url { get; set; }
    public string subscriptions_url { get; set; }
    public string organizations_url { get; set; }
    public string repos_url { get; set; }
    public string events_url { get; set; }
    public string received_events_url { get; set; }
    public string type { get; set; }
    public bool site_admin { get; set; }
}