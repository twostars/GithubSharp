// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace GithubSharp.Core.Models.Repositories
{
    public class File
    {
        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("additions")]
        public int Additions { get; set; }

        [JsonProperty("deletions")]
        public int Deletions { get; set; }

        [JsonProperty("changes")]
        public int Changes { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("raw_url")]
        public string RawUrl { get; set; }

        [JsonProperty("blob_url")]
        public string BlobUrl { get; set; }

        [JsonProperty("patch")]
        public string Patch { get; set; }
    }
}
