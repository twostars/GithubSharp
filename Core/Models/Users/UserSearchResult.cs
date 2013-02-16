// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GithubSharp.Core.Models.Users
{
    public class UserSearchResult
    {
        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("followers")]
        public int Followers { get; set; }

        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        [JsonProperty("fullname")]
        public string Fullname { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("public_repo_count")]
        public int PublicRepoCount { get; set; }

        [JsonProperty("repos")]
        public int Repos { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
