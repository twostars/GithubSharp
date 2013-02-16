using System.Globalization;
using System.Linq;
using GithubSharp.Core.API;
using GithubSharp.Core.Services.Implementation;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class PullRequestFixture
    {
        [Test]
        public void CanGetPullRequests()
        {
            var pullrequestApi = new PullRequest(new BasicCacher(), new NullLogger());
            var pullrequest = pullrequestApi.List("rhysc", "GithubSharp");
            Assert.NotNull(pullrequest);
            Assert.IsNotEmpty(pullrequest.ToArray());
        }

        [Test]
        public void CanGetOpenPullRequests()
        {
            var pullrequestApi = new PullRequest(new BasicCacher(), new NullLogger());
            var openPullrequests = pullrequestApi.List("rhysc", "GithubSharp", "open");
            Assert.NotNull(openPullrequests);
            Assert.IsNotEmpty(openPullrequests.ToArray());
            Assert.AreEqual(1, openPullrequests.First().Number);
        }
        [Test]
        public void CanGetClosedPullRequests()
        {
            var pullrequestApi = new PullRequest(new BasicCacher(), new NullLogger());
            var closedPullrequest = pullrequestApi.List("rhysc", "GithubSharp", "closed");
            Assert.NotNull(closedPullrequest);
            Assert.IsNotEmpty(closedPullrequest.ToArray());
            Assert.AreEqual(2, closedPullrequest.First().Number);
        }

        [Test]
        public void CanGetPullRequestById()
        {
            var pullrequestApi = new PullRequest(new BasicCacher(), new NullLogger());
            var pullrequest = pullrequestApi.GetById("rhysc", "GithubSharp", 1.ToString(CultureInfo.InvariantCulture));
            Assert.NotNull(pullrequest);
            Assert.AreEqual("RhysC", pullrequest.User.Login);
            Assert.AreEqual(1, pullrequest.Number);
        }
    }
}
