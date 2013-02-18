// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Repositories
{
    public class User
    {
        [JsonProperty("gravatar_id")]
        public string GravatarId { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }
    }
}
