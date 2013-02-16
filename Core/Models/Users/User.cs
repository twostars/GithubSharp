// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Users
{
    public class User : UserSummary
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("blog")]
        public string Blog { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("hireable")]
        public bool Hireable { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("public_repos")]
        public int PublicRepos { get; set; }

        [JsonProperty("followers")]
        public int Followers { get; set; }

        [JsonProperty("following")]
        public int Following { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("public_gists")]
        public int PublicGists { get; set; }
    }
}
