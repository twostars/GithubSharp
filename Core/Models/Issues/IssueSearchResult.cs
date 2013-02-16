// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System.Collections.Generic;
using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Issues
{

    public class IssueSearchResult
    {

        [JsonProperty("labels")]
        public IList<object> Labels { get; set; }

        [JsonProperty("votes")]
        public int Votes { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("position")]
        public double Position { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("gravatar_id")]
        public string GravatarId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("comments")]
        public int Comments { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
    }
}
