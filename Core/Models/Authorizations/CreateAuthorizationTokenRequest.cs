// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Authorizations
{
    /// <summary>
    /// http://developer.github.com/v3/oauth/#create-a-new-authorization
    /// </summary>
    public class CreateAuthorizationTokenRequest
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("note_url")]
        public string NoteUrl { get; set; }

        /// <summary>
        /// http://developer.github.com/v3/oauth/#scopes
        /// </summary>
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }
    }
}
