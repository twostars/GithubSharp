using System.Globalization;
using System.Linq;
using GithubSharp.Core.API;
using GithubSharp.Core.Base;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{

    [TestFixture]
    public class BasicAuthenticatedPullRequestFixture : AuthenticatedPullRequestFixture
    {
        protected override IRequestProxy GetProxyWithAuthProvider()
        {
            return RequestProxyProvider.Basic();
        }
    }
    [TestFixture]
    public class OAuthAuthenticatedPullRequestFixture : AuthenticatedPullRequestFixture
    {
        protected override IRequestProxy GetProxyWithAuthProvider()
        {
            return RequestProxyProvider.OAuth();
        }
    }

    public abstract class AuthenticatedPullRequestFixture
    {
        private PullRequestsRepository _pullrequestApi;

        [SetUp]
        public void SetUp()
        {
            _pullrequestApi = new PullRequestsRepository(GetProxyWithAuthProvider());
        }

        [Test]
        public void CanGetPullRequests()
        {
            var pullrequest = _pullrequestApi.List("rhysc", "GithubSharp");
            Assert.NotNull(pullrequest);
            Assert.IsNotEmpty(pullrequest.ToArray());
        }

        [Test]
        public void CanGetOpenPullRequests()
        {
            var openPullrequests = _pullrequestApi.List("rhysc", "GithubSharp", "open");
            Assert.NotNull(openPullrequests);
            Assert.IsNotEmpty(openPullrequests.ToArray());
            Assert.AreEqual(1, openPullrequests.First().Number);
        }
        [Test]
        public void CanGetClosedPullRequests()
        {
            var closedPullrequest = _pullrequestApi.List("rhysc", "GithubSharp", "closed");
            Assert.NotNull(closedPullrequest);
            Assert.IsNotEmpty(closedPullrequest.ToArray());
            Assert.AreEqual(2, closedPullrequest.First().Number);
        }

        [Test]
        public void CanGetPullRequestById()
        {
            var pullrequest = _pullrequestApi.GetById("rhysc", "GithubSharp", 1.ToString(CultureInfo.InvariantCulture));
            Assert.NotNull(pullrequest);
            Assert.AreEqual("RhysC", pullrequest.User.Login);
            Assert.AreEqual(1, pullrequest.Number);
        }

        protected abstract IRequestProxy GetProxyWithAuthProvider();
    }
}
