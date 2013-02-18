using System.Configuration;
using System.Linq;
using GithubSharp.Core.API;
using GithubSharp.Core.Models.Authorizations;
using GithubSharp.Core.Services;
using GithubSharp.Core.Services.Implementation;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class BasicAuthorizationsRepositoryFixture : AuthorizationsRepositoryFixture
    {
        protected override IAuthenticationProvider GetAuthProvider()
        {
            return AuthenticationProvider.Basic();
        }
    }
    [TestFixture]
    public class OAuthAuthorizationsRepositoryFixture : AuthorizationsRepositoryFixture
    {
        protected override IAuthenticationProvider GetAuthProvider()
        {
            return AuthenticationProvider.OAuth();
        }
    }

    public abstract class AuthorizationsRepositoryFixture
    {
        private string _username;
        private string _clientId;
        private string _clientsecret;
        private AuthorizationsRepository _authrepo;

        [SetUp]
        public void SetUp()
        {
            _clientId = ConfigurationManager.AppSettings["clientid"];
            _clientsecret = ConfigurationManager.AppSettings["clientsecret"];
            _username = ConfigurationManager.AppSettings["username"];
            var password = ConfigurationManager.AppSettings["password"];

            _authrepo = new AuthorizationsRepository(new ConsoleLogger(), new BasicAuthenticationProvider(_username, password));

        }

        protected abstract IAuthenticationProvider GetAuthProvider();

        [Test]
        public void CanGetOAuthTokens()
        {
            var tokens = _authrepo.GetTokens();
            Assert.NotNull(tokens);
            Assert.IsNotEmpty(tokens);
        }

        [Test]
        public void CanCreateAndRemoveOAuthToken()
        {
            var request = new CreateAuthorizationTokenRequest
               {
                   ClientId = _clientId,
                   ClientSecret = _clientsecret,
                   Note = "NUnitTest",
                   Scopes = new[] { "user", "repo" }
               };
            var response = _authrepo.CreateNewAuthToken(request);
            Assert.IsNotNull(response);
            Assert.IsNotEmpty(response.Scopes);
            Assert.True(response.Scopes.Any(s => s == "user"));
            Assert.IsNotNull(response.App);
            Assert.AreEqual("githubsharp", response.App.Name.ToLowerInvariant());

            _authrepo.RemoveAuthToken(response.Id);
            //assert they are gone
            var tokens = _authrepo.GetTokens();
            Assert.IsFalse(tokens.Any(t => t.Id == response.Id));
        }
    }
}
