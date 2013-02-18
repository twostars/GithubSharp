// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Repositories
{
    public class TagOrBranch
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("commit")]
        public Tree Commit { get; set; }

        [JsonProperty("zipball_url")]
        public string ZipballUrl { get; set; }

        [JsonProperty("tarball_url")]
        public string TarballUrl { get; set; }
    }
}
