using System.Configuration;
using System.Linq;
using GithubSharp.Core.API;
using GithubSharp.Core.Base;
using GithubSharp.Core.Models.Authorizations;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class AuthorizationsRepositoryFixture
    {
        private string _clientId;
        private string _clientsecret;
        private AuthorizationsRepository _authrepo;

        [SetUp]
        public void SetUp()
        {
            _clientId = ConfigurationManager.AppSettings["clientid"];
            _clientsecret = ConfigurationManager.AppSettings["clientsecret"];
            //We can only do this with Basic as this is setting up so we can use OAuth
            _authrepo = new AuthorizationsRepository(RequestProxyProvider.Basic());
        }

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
