using GithubSharp.Core.API;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class IssuesFixture
    {
        private IssuesRepository _issueRepositoryApi;

        [SetUp]
        public void SetUp()
        {
            _issueRepositoryApi = new IssuesRepository(RequestProxyProvider.Basic());
        }

        [Test]
        public void CanListRepoIssues()
        {
            var issues = _issueRepositoryApi.List("GithubSharp", "rhysc", IssueState.Open);
            Assert.IsNotNull(issues);
            Assert.IsNotEmpty(issues);
        }

        [Test]
        public void CanGetIssues()
        {
            var issue = _issueRepositoryApi.View("GithubSharp", "rhysc", 3);
            Assert.IsNotNull(issue);
        }

        [Test]
        public void CanSearchIssues()
        {
            var issues = _issueRepositoryApi.Search("GithubSharp", "rhysc", IssueState.Open, "Sample");
            Assert.IsNotNull(issues);
            Assert.IsNotEmpty(issues);
        }

        [Test]
        public void CanListIssuesLabel()
        {
            var labels = _issueRepositoryApi.Labels("GithubSharp", "rhysc", 3);
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
            var comments = _issueRepositoryApi.Comments("GithubSharp", "rhysc", 3);
            Assert.IsNotNull(comments);
            Assert.IsNotEmpty(comments);
            
        }
    }
}
