using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Repositories
{
    public class CommitDetails : Commit
    {
        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("files")]
        public File[] Files { get; set; }
    }
}