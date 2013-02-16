// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Issues
{

    public class IssueComment
    {

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("issue_url")]
        public string IssueUrl { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
