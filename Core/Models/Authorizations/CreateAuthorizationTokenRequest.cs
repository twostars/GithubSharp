// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GithubSharp.Core.Models.Authorizations
{
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

        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }
    }
}
