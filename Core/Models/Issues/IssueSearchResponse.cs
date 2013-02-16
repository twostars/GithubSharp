// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Issues
{

    public class IssueSearchResponse
    {
        [JsonProperty("issues")]
        public IssueSearchResult[] Issues { get; set; }
    }
}
