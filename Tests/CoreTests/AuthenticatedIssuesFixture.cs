using System;
using System.Configuration;
using System.Linq;
using GithubSharp.Core.API;
using GithubSharp.Core.Models.Issues;
using GithubSharp.Core.Services;
using GithubSharp.Plugins.LogProviders.NullLogger;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class AuthenticatedIssuesFixture
    {
        private AuthenticatedIssuesRepository _issuesRepositoryApi;
        private string _privateRepository;
        private string _privateOrg;

        [SetUp]
        public void SetUp()
        {
            var username = ConfigurationManager.AppSettings["username"];
            var password = ConfigurationManager.AppSettings["password"];
            _privateRepository = ConfigurationManager.AppSettings["privaterepo"];
            _privateOrg = ConfigurationManager.AppSettings["privateorg"];
            _issuesRepositoryApi = new AuthenticatedIssuesRepository(new BasicCacher.BasicCacher(), new ConsoleLogger(),
                                                                     new BasicAuthenticationProvider(username, password));
        }

        [Test]
        public void CanGetIssuesByAuthUsername()
        {
            var issues = _issuesRepositoryApi.Get();
            Assert.NotNull(issues);
            Assert.IsNotEmpty(issues);
        }

        [Test]
        public void CanGetIssuesForOrgByAuthUsername()
        {
            var issues = _issuesRepositoryApi.GetForOrganization(_privateOrg);
            Assert.NotNull(issues);
        }
        [Test]
        public void CanCreateAndCommentAndDeleteIssues()
        {
            var title = Guid.NewGuid().ToString();
            var body = Guid.NewGuid().ToString();
            var request = new CreateIssueRequest(title, body) { Assignee = "rhysc", Labels = new[] { "Test1", "Test2" } };
            var issue = _issuesRepositoryApi.Create("githubsharp", "rhysc", request);
            Assert.NotNull(issue);
            Assert.AreEqual(title, issue.Title);
            Assert.AreEqual(body, issue.Body);
            Assert.AreEqual(title, issue.Title);
            Assert.True(issue.Labels.Any(l => l.Name == "Test1"));
            Assert.True(issue.Labels.Any(l => l.Name == "Test2"));
            Assert.AreEqual("RhysC", issue.Assignee.Login);

            var comment = Guid.NewGuid().ToString();
            var commentedIsssue = _issuesRepositoryApi.CommentOnIssue("githubsharp", "rhysc", issue.Number, comment);
            Assert.AreEqual(comment, commentedIsssue.Body);

            var closedIssue = _issuesRepositoryApi.Close("githubsharp", "rhysc", issue.Number);
            Assert.NotNull(closedIssue);
            Assert.AreEqual(title, closedIssue.Title);
            Assert.AreEqual(body, closedIssue.Body);
            Assert.AreEqual(title, closedIssue.Title);
            Assert.AreEqual("RhysC", closedIssue.Assignee.Login);
            Assert.AreEqual("closed", closedIssue.State);
            Assert.True(DateTime.UtcNow.AddSeconds(-5) < closedIssue.ClosedAt && closedIssue.ClosedAt < DateTime.UtcNow.AddSeconds(1));
        }
    }
}