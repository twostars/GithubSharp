using System.Configuration;
using GithubSharp.Core.API;
using GithubSharp.Core.Services;
using GithubSharp.Plugins.LogProviders.NullLogger;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class AuthenticatedRepositoryFixture
    {
        private AuthenticatedRepository _repoApi;
        private string privateRepository;

        [SetUp]
        public void SetUp()
        {
            var username = ConfigurationManager.AppSettings["username"];
            var password = ConfigurationManager.AppSettings["password"];
            privateRepository = ConfigurationManager.AppSettings["privaterepo"];
            _repoApi = new AuthenticatedRepository(new BasicCacher.BasicCacher(), new NullLogger(), new BasicAuthenticationProvider(username, password));
        }

        [Test]
        public void CanGetPrivateRepository()
        {
            var repos = _repoApi.Get("rhysc", privateRepository);
            Assert.NotNull(repos);
            Assert.AreEqual(privateRepository, repos.Name);
        }
    }
}