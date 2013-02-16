using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Issues
{
    public class IssueCommentCreateRequest
    {

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}