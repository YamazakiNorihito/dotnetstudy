using System.ComponentModel;

namespace GitHubApi;

public class GitHubSearchQuery
{
    public string type { get; set; }
    public string Is { get; set; }
    public string Mentions { get; set; }

    [DisplayName("review-requested")] public string ReviewRequested { get; set; }

    public string ToQueryString() =>
        string.Join("+", this.GetType().GetProperties()
            .Where(p => p.GetValue(this) is not null)
            .Select(p =>
            {
                var displayName = p.GetCustomAttributes(typeof(DisplayNameAttribute), false)
                    .Cast<DisplayNameAttribute>()
                    .SingleOrDefault();
                var name = displayName != null ? displayName.DisplayName.ToLower() : p.Name.ToLower();
                return $"{name}:{p.GetValue(this)}";
            }));
}