// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using GithubSharp.Core.Models.Repositories;
using Newtonsoft.Json;

namespace GithubSharp.Core.Models.PullRequests
{
    public class Head
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("ref")]
        public string Ref { get; set; }

        [JsonProperty("sha")]
        public string Sha { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("repo")]
        public Repo Repo { get; set; }
    }
}
