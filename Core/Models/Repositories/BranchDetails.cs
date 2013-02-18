// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Repositories
{
    public class BranchDetails
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("commit")]
        public Commit Commit { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }
}
