// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Users
{
    public class AuthenticatedUser : User
    {
        [JsonProperty("total_private_repos")]
        public int TotalPrivateRepos { get; set; }

        [JsonProperty("owned_private_repos")]
        public int OwnedPrivateRepos { get; set; }

        [JsonProperty("disk_usage")]
        public int DiskUsage { get; set; }

        [JsonProperty("collaborators")]
        public int Collaborators { get; set; }

        [JsonProperty("plan")]
        public Plan Plan { get; set; }

        [JsonProperty("private_gists")]
        public int PrivateGists { get; set; }
    }
}
