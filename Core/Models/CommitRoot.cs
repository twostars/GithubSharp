using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GithubSharp.Core.Models
{
    public class CommitRoot
    {
        [DataMember(Name = "parents")]
        public List<CommmitParent> Parents { get; set; }

        [DataMember(Name = "author")]
        public Person Author { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "sha")]
        public string Sha { get; set; }

        [DataMember(Name = "commit")]
        public CommitDetails Commit { get; set; }

        [DataMember(Name = "committer")]
        public Person Committer { get; set; }
    }

    public class CommitDetails
    {
        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "author")]
        public CommitAuthor Author { get; set; }

        [DataMember(Name = "committer")]
        public CommitAuthor Committer { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "tree")]
        public CommmitParent Tree { get; set; }

    }

    public class CommmitParent
    {
        [DataMember(Name = "sha")]
        public string Sha { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }
    }

    public class Person
    {
        [DataMember(Name = "login")]
        public string Login { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
    public class CommitAuthor
    {
        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }

    [DataContract]
    public class SingleFileCommit
    {
        [DataMember(Name = "sha")]
        public string Sha { get; set; }
        [DataMember(Name = "commit")]
        public CommitDetails Details { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }
        [DataMember(Name = "comments_url")]
        public string CommentsUrl { get; set; }
        [DataMember(Name = "files")]
        public FileCommit[] Files { get; set; }
        [DataMember(Name = "stats")]
        public CommitStats Stats { get; set; }
    }

    [DataContract]
    public class FileCommit
    {
        [DataMember(Name = "additions")]
        public string NumberOfAdditions { get; set; }
        [DataMember(Name = "blob_url")]
        public string BlobUrl { get; set; }
        [DataMember(Name = "changes")]
        public string Changes { get; set; }
        [DataMember(Name = "contents_url")]
        public string ContentsUrl { get; set; }
        [DataMember(Name = "deletions")]
        public string Deletions { get; set; }
        [DataMember(Name = "filename")]
        public string Filename { get; set; }
        [DataMember(Name = "patch")]
        public string Patch { get; set; }
        [DataMember(Name = "raw_url")]
        public string RawUrl { get; set; }
        [DataMember(Name = "sha")]
        public string Sha { get; set; }
        [DataMember(Name = "status")]
        public string Status { get; set; }

    }

    [DataContract]
    public class CommitStats
    {
        [DataMember(Name = "additions")]
        public int NumberOfAdditions { get; set; }
        [DataMember(Name = "deletions")]
        public int NumberOfDeltions { get; set; }
        [DataMember(Name = "total")]
        public string Total { get; set; }
    }
}
