// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using GithubSharp.Core.Models.Repositories;
using Newtonsoft.Json;

namespace GithubSharp.Core.Models.PullRequests
{

    public class Repo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("owner")]
        public User Owner { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("private")]
        public bool Private { get; set; }

        [JsonProperty("fork")]
        public bool Fork { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("clone_url")]
        public string CloneUrl { get; set; }

        [JsonProperty("git_url")]
        public string GitUrl { get; set; }

        [JsonProperty("ssh_url")]
        public string SshUrl { get; set; }

        [JsonProperty("svn_url")]
        public string SvnUrl { get; set; }

        [JsonProperty("mirror_url")]
        public string MirrorUrl { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }

        [JsonProperty("language")]
        public object Language { get; set; }

        [JsonProperty("forks")]
        public int Forks { get; set; }

        [JsonProperty("forks_count")]
        public int ForksCount { get; set; }

        [JsonProperty("watchers")]
        public int Watchers { get; set; }

        [JsonProperty("watchers_count")]
        public int WatchersCount { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("master_branch")]
        public string MasterBranch { get; set; }

        [JsonProperty("open_issues")]
        public int OpenIssues { get; set; }

        [JsonProperty("pushed_at")]
        public string PushedAt { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}
