// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Repositories
{
    public class Commit
    {
        [JsonProperty("sha")]
        public string Sha { get; set; }

        [JsonProperty("commit")]
        public CommitSummary CommitSummary { get; set; }

        [JsonProperty("author")]
        public User Author { get; set; }

        [JsonProperty("parents")]
        public Tree[] Parents { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("committer")]
        public Committer Committer { get; set; }
    }
}
