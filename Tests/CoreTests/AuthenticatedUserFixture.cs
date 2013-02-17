using System;
using System.Configuration;
using System.Linq;
using GithubSharp.Core.API;
using GithubSharp.Core.Services.Implementation;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class AuthenticatedUserFixture
    {
        private AuthenticatedUserRepository _userRepositoryApi;
        private string _username;

        [SetUp]
        public void SetUp()
        {
            _username = ConfigurationManager.AppSettings["username"];
            var password = ConfigurationManager.AppSettings["password"];

            _userRepositoryApi = new AuthenticatedUserRepository(new BasicCacher(), new NullLogger(), new BasicAuthenticationProvider(_username, password));
        }

        [Test]
        public void CurrentUserCanBeRetrievedWithoutName()
        {
            var user = _userRepositoryApi.Get();
            Assert.NotNull(user);
            Assert.AreEqual(_username.ToLowerInvariant(), user.Login.ToLowerInvariant());
            Assert.AreEqual(("https://api.github.com/users/" + _username).ToLowerInvariant(), user.Url.ToLowerInvariant());
        }

        [Test]
        public void CanGetCurrentUserPublicKeys()
        {
            var keys = _userRepositoryApi.PublicKeys();
            Assert.NotNull(keys);
            Assert.IsNotEmpty(keys);
            foreach (var publicKey in keys)
            {
                Assert.IsNotNullOrEmpty(publicKey.Title);
                Assert.IsNotNullOrEmpty(publicKey.Key);
                Assert.IsNotNullOrEmpty(publicKey.Url);
            }
        }

        [Test]
        public void CanGetCurrentUserEmails()
        {
            var emails = _userRepositoryApi.Emails();
            Assert.NotNull(emails);
            Assert.IsNotEmpty(emails);
            foreach (var email in emails)
            {
                Assert.IsNotNullOrEmpty(email);
            }
        }

        [Test]
        public void CanAddAndRemoveEmails()
        {
            var email1 = Guid.NewGuid() + "@contso.com";
            var email2 = Guid.NewGuid() + "@contso.com";
            var emails = _userRepositoryApi.AddEmails(new[] { email1, email2 });
            Assert.NotNull(emails);
            Assert.IsTrue(emails.Any(e => e == email1));
            Assert.IsTrue(emails.Any(e => e == email2));

            _userRepositoryApi.RemoveEmail(new[] { email1, email2 });

            var cleanEmails = _userRepositoryApi.Emails();

            Assert.NotNull(cleanEmails);
            Assert.IsNotEmpty(cleanEmails);
            Assert.IsFalse(cleanEmails.Any(e => e == email1));
            Assert.IsFalse(cleanEmails.Any(e => e == email2));

        }
    }
}