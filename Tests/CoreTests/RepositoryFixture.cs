using System.Linq;
using GithubSharp.Core.API;
using GithubSharp.Plugins.LogProviders.NullLogger;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class RepositoryFixture
    {
        private Repository _repoApi;

        [SetUp]
        public void SetUp()
        {
            _repoApi = new Repository(new BasicCacher.BasicCacher(), new NullLogger());
        }

        [Test]
        public void CanGetRepository()
        {
            var repos = _repoApi.Get("rhysc", "GithubSharp");
            Assert.NotNull(repos);
            Assert.AreEqual("GithubSharp", repos.Name);
        }

        [Test]
        public void CanSearchRepositories()
        {
            var repos = _repoApi.Search("GithubSharp").ToArray();
            Assert.NotNull(repos);
            Assert.IsNotEmpty(repos);
            Assert.IsNotEmpty(repos.Where(r => r.Username == "RhysC").ToArray());
        }

        [Test]
        public void CanGetRepositoryTags()
        {
            var tags = _repoApi.Tags("GithubSharp", "RhysC").ToArray();
            Assert.NotNull(tags);
            Assert.IsNotEmpty(tags);
            Assert.IsNotEmpty(tags.Where(t => t.Name == "v0.00").ToArray());//I have put a tag on this repo
        }

        [Test]
        public void CanGetRepositoryBranches()
        {
            var tags = _repoApi.Branches("GithubSharp", "RhysC").ToArray();
            Assert.NotNull(tags);
            Assert.IsNotEmpty(tags);
            Assert.IsNotEmpty(tags.Where(t => t.Name == "PullRequestDemo").ToArray());
        }
    }
}
