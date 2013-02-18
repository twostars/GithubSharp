// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GithubSharp.Core.Models.Repositories
{
    public class RepositoriesSearchResult
    {
        [JsonProperty("repositories")]
        public RepositorySearchResult[] Repositories { get; set; }
    }
}
