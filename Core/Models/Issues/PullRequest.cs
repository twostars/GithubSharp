// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Issues
{

    public class PullRequest
    {

        [JsonProperty("diff_url")]
        public object DiffUrl { get; set; }

        [JsonProperty("html_url")]
        public object HtmlUrl { get; set; }

        [JsonProperty("patch_url")]
        public object PatchUrl { get; set; }
    }
}
