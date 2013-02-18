// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Repositories
{
    public class Tree
    {
        [JsonProperty("sha")]
        public string Sha { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
