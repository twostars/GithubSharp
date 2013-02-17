// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Authorizations
{
    public class CreateAuthorizationTokenResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("app")]
        public App App { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("note_url")]
        public string NoteUrl { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
    }
}
