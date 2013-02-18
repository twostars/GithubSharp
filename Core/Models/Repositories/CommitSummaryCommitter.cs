// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Repositories
{
    public class CommitSummaryCommitter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
