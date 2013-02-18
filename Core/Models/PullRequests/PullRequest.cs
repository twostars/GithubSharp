// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using GithubSharp.Core.Models.Repositories;
using Newtonsoft.Json;

namespace GithubSharp.Core.Models.PullRequests
{
    public class PullRequest
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("diff_url")]
        public string DiffUrl { get; set; }

        [JsonProperty("patch_url")]
        public string PatchUrl { get; set; }

        [JsonProperty("issue_url")]
        public string IssueUrl { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("closed_at")]
        public string ClosedAt { get; set; }

        [JsonProperty("merged_at")]
        public string MergedAt { get; set; }

        [JsonProperty("head")]
        public Head Head { get; set; }

        [JsonProperty("base")]
        public Base Base { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
