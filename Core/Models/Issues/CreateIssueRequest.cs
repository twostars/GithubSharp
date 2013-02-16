using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Issues
{
    public class CreateIssueRequest
    {
        public CreateIssueRequest() { }
        public CreateIssueRequest(string title, string body)
        {
            Title = title;
            Body = body;
        }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("assignee")]
        public string Assignee { get; set; }
        [JsonProperty("milestone")]
        public string Milestone { get; set; }
        [JsonProperty("labels")]
        public string[] Labels { get; set; }

    }
    public class IssueUpdateRequest : CreateIssueRequest
    {
        [JsonProperty("state")]
        public string State { get; set; }
    }
}