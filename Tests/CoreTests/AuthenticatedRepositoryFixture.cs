using System.Configuration;
using GithubSharp.Core.API;
using GithubSharp.Core.Base;
using GithubSharp.Core.Services;
using GithubSharp.Core.Services.Implementation;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class BasicAuthenticatedRepositoryFixture : AuthenticatedRepositoryFixture
    {
        protected override IRequestProxy GetProxyWithAuthProvider()
        {
            return RequestProxyProvider.Basic();
        }
    }
    [TestFixture]
    public class OAuthAuthenticatedRepositoryFixture : AuthenticatedRepositoryFixture
    {
        protected override IRequestProxy GetProxyWithAuthProvider()
        {
            return RequestProxyProvider.OAuth();
        }
    }

    public abstract class AuthenticatedRepositoryFixture
    {
        private RepositoryRepository _repoApi;
        private string _privateRepository;

        [SetUp]
        public void SetUp()
        {
            _privateRepository = ConfigurationManager.AppSettings["privaterepo"];
            _repoApi = new RepositoryRepository(GetProxyWithAuthProvider());
        }
        protected abstract IRequestProxy GetProxyWithAuthProvider();

        [Test]
        public void CanGetPrivateRepository()
        {
            var repos = _repoApi.Get("rhysc", _privateRepository);
            Assert.NotNull(repos);
            Assert.AreEqual(_privateRepository, repos.Name);
        }
    }
}