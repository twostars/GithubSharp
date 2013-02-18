// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Repositories
{
    public class Stats
    {
        [JsonProperty("additions")]
        public int Additions { get; set; }

        [JsonProperty("deletions")]
        public int Deletions { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
