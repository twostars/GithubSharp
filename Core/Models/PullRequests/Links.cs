// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.PullRequests
{
    public class Links
    {
        [JsonProperty("self")]
        public Self Self { get; set; }

        [JsonProperty("html")]
        public Html Html { get; set; }

        [JsonProperty("comments")]
        public Comments Comments { get; set; }

        [JsonProperty("review_comments")]
        public ReviewComments ReviewComments { get; set; }
    }
}
