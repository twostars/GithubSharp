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
            var tags = _repoApi.Tags("GithubSharp", "RhysC");
            Assert.NotNull(tags);
            Assert.IsNotEmpty(tags);
            Assert.IsNotEmpty(tags.Where(t => t.Name == "v0.00").ToArray());//I have put a tag on this repo
        }

        [Test]
        public void CanGetRepositoryBranches()
        {
            var branches = _repoApi.Branches("GithubSharp", "RhysC");
            Assert.NotNull(branches);
            Assert.IsNotEmpty(branches);
            Assert.IsNotEmpty(branches.Where(t => t.Name == "PullRequestDemo").ToArray());
        }

        [Test]
        public void CanListUsersRepositories()
        {
            var repos = _repoApi.List("RhysC").ToArray();
            Assert.NotNull(repos);
            Assert.IsNotEmpty(repos);
            Assert.IsNotEmpty(repos.Where(t => t.Name == "GithubSharp").ToArray());
        }

        [Test]
        public void CanGetRepositoriesLanguage()
        {
            var repos = _repoApi.LanguageBreakDown("GithubSharp", "RhysC").ToArray();
            Assert.NotNull(repos);
            Assert.IsNotEmpty(repos);
            Assert.IsNotEmpty(repos.Where(t => t.Key == "C#").ToArray());
        }
    }
}
