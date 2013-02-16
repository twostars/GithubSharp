// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Users
{
    public class Plan
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("space")]
        public int Space { get; set; }

        [JsonProperty("collaborators")]
        public int Collaborators { get; set; }

        [JsonProperty("private_repos")]
        public int PrivateRepos { get; set; }
    }
}
