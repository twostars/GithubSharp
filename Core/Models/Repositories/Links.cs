// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Repositories
{
    public class Links
    {
        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("self")]
        public string Self { get; set; }
    }
}
