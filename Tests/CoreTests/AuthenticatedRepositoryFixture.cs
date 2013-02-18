using System.Configuration;
using GithubSharp.Core.API;
using GithubSharp.Core.Services;
using GithubSharp.Core.Services.Implementation;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class BasicAuthenticatedRepositoryFixture : AuthenticatedRepositoryFixture
    {
        protected override IAuthenticationProvider GetAuthProvider()
        {
            return AuthenticationProvider.Basic();
        }
    }
    [TestFixture]
    public class OAuthAuthenticatedRepositoryFixture : AuthenticatedRepositoryFixture
    {
        protected override IAuthenticationProvider GetAuthProvider()
        {
            return AuthenticationProvider.OAuth();
        }
    }

    public abstract class AuthenticatedRepositoryFixture
    {
        private AuthenticatedRepository _repoApi;
        private string _privateRepository;

        [SetUp]
        public void SetUp()
        {
            var username = ConfigurationManager.AppSettings["username"];
            var password = ConfigurationManager.AppSettings["password"];
            _privateRepository = ConfigurationManager.AppSettings["privaterepo"];
            _repoApi = new AuthenticatedRepository(new NullLogger(), new BasicAuthenticationProvider(username, password));
        }
        protected abstract IAuthenticationProvider GetAuthProvider();

        [Test]
        public void CanGetPrivateRepository()
        {
            var repos = _repoApi.Get("rhysc", _privateRepository);
            Assert.NotNull(repos);
            Assert.AreEqual(_privateRepository, repos.Name);
        }
    }
}