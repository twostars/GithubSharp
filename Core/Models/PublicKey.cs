using System.Runtime.Serialization;

namespace GithubSharp.Core.Models
{
    [DataContract]
    public class PublicKey
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }
    }
}