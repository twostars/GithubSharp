// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Repositories
{
    public class RepositorySearchResult
    {
        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("followers")]
        public int Followers { get; set; }

        [JsonProperty("fork")]
        public bool Fork { get; set; }

        [JsonProperty("forks")]
        public int Forks { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("private")]
        public bool Private { get; set; }

        [JsonProperty("pushed")]
        public string Pushed { get; set; }

        [JsonProperty("pushed_at")]
        public string PushedAt { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("watchers")]
        public int Watchers { get; set; }
    }
}
