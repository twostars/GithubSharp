using System;
using System.Configuration;
using System.Linq;
using GithubSharp.Core.API;
using GithubSharp.Core.Models.Issues;
using GithubSharp.Core.Services;
using GithubSharp.Core.Services.Implementation;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class BasicAuthenticatedIssuesFixture : AuthenticatedIssuesFixture
    {
        protected override IAuthenticationProvider GetAuthProvider()
        {
            return AuthenticationProvider.Basic();
        }
    }
    [TestFixture]
    public class OAuthAuthenticatedIssuesFixture : AuthenticatedIssuesFixture
    {
        protected override IAuthenticationProvider GetAuthProvider()
        {
            return AuthenticationProvider.OAuth();
        }
    }

    public abstract class AuthenticatedIssuesFixture
    {
        protected abstract IAuthenticationProvider GetAuthProvider();

        private AuthenticatedIssuesRepository _issuesRepositoryApi;

        private string _privateOrg;

        [SetUp]
        public void SetUp()
        {
            _privateOrg = ConfigurationManager.AppSettings["privateorg"];
            _issuesRepositoryApi = new AuthenticatedIssuesRepository(new ConsoleLogger(), GetAuthProvider());
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
            Console.WriteLine("closedat - {0}, Utc Now - {1}", closedIssue.ClosedAt, DateTime.UtcNow);
            Assert.True(DateTime.UtcNow.AddMinutes(-2) < closedIssue.ClosedAt && closedIssue.ClosedAt < DateTime.UtcNow.AddMinutes(2));
        }
    }
}