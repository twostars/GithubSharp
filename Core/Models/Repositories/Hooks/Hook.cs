// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Repositories.Hooks
{
    public class Hook
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("events")]
        public string[] Events { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("config")]
        public Config Config { get; set; }//TODO - NOTE this may be dynamic.. investigating

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
