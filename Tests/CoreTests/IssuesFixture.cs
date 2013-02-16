using GithubSharp.Core.API;
using GithubSharp.Core.Models;
using GithubSharp.Plugins.LogProviders.NullLogger;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class IssuesFixture
    {
        private Issues _issueApi;

        [SetUp]
        public void SetUp()
        {
            _issueApi = new Issues(new BasicCacher.BasicCacher(), new NullLogger());
        }

        [Test]
        public void CanListRepoIssues()
        {
            var issues = _issueApi.List("GithubSharp", "rhysc", IssueState.Open);
            Assert.IsNotNull(issues);
            Assert.IsNotEmpty(issues);
        }

        [Test]
        public void CanGetIssues()
        {
            var issue = _issueApi.View("GithubSharp", "rhysc", 3);
            Assert.IsNotNull(issue);
        }

        [Test]
        public void CanSearchIssues()
        {
            var issues = _issueApi.Search("GithubSharp", "rhysc", IssueState.Open, "Sample");
            Assert.IsNotNull(issues);
            Assert.IsNotEmpty(issues);
        }

        [Test]
        public void CanListIssuesLabel()
        {
            var labels = _issueApi.Labels("GithubSharp", "rhysc", 3);
            Assert.IsNotNull(labels);
            Assert.IsNotEmpty(labels);
            foreach (var issueLabel in labels)
            {
                Assert.IsNotNullOrEmpty(issueLabel.Color);
                Assert.IsNotNullOrEmpty(issueLabel.Url);
                Assert.IsNotNullOrEmpty(issueLabel.Name);
            }
        }

        [Test]
        public void CanListIssuesComments()
        {
            var comments = _issueApi.Comments("GithubSharp", "rhysc", 3);
            Assert.IsNotNull(comments);
            Assert.IsNotEmpty(comments);
            
        }
    }
}
