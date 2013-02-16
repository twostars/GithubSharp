using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GithubSharp.Core.API;
using GithubSharp.Core.Services.Implementation;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class CommitsFixture
    {
        private Commits _commitApi;

        [SetUp]
        public void SetUp()
        {
            _commitApi = new Commits(new BasicCacher(), new NullLogger());
        }

        [Test]
        public void CanGetCommitsFromBranch()
        {
            var commits = _commitApi.CommitsForBranch("Rhysc", "GithubSharp", "master");
            Assert.IsNotNull(commits);
            Assert.IsNotEmpty(commits);
        }
        [Test]
        public void CanGetCommitsForSingleFile()
        {
            var commits = _commitApi.CommitsForBranch("Rhysc", "GithubSharp", "master");
            var sha = commits.Last().Sha;

            var commit = _commitApi.CommitForSingleFile("Rhysc", "GithubSharp", sha);
            Assert.IsNotNull(commit);
            Assert.AreEqual(sha, commit.Sha);
        }

        [Test]
        public void CanGetCommitsPath()
        {
            var commits = _commitApi.CommitsForPath("Rhysc", "GithubSharp", "PullRequestDemo", @"/Tests/CoreTests/UserFixture.cs");
            Assert.IsNotNull(commits);
            Assert.IsNotEmpty(commits);
            foreach (var commit in commits)
            {
                Assert.IsNotNullOrEmpty(commit.Sha);
                Assert.NotNull(commit.Commit.Author.Email);//Could assert on all props...
            }
        }
    }
}
