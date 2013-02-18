// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Repositories
{
    public class CommitSummary
    {
        [JsonProperty("author")]
        public CommitSummaryAuthor Author { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("tree")]
        public Tree Tree { get; set; }

        [JsonProperty("committer")]
        public CommitSummaryCommitter Committer { get; set; }
    }
}
