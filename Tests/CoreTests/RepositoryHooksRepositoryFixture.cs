using System.Collections.Generic;
using GithubSharp.Core.API;
using GithubSharp.Core.Base;
using GithubSharp.Core.Models.Repositories.Hooks;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class BasicAuthRepositoryHooksRepositoryFixture : RepositoryHooksRepositoryFixture
    {
        protected override IRequestProxy GetAuthProvider()
        {
            return RequestProxyProvider.Basic();
        }
    }
    [TestFixture]
    public class OAuthAuthRepositoryHooksRepositoryFixture : RepositoryHooksRepositoryFixture
    {
        protected override IRequestProxy GetAuthProvider()
        {
            return RequestProxyProvider.OAuth();
        }
    }

    public abstract class RepositoryHooksRepositoryFixture
    {
        protected RepositoryHooksRepository Hooksrepo;

        [SetUp]
        public void SetUp()
        {
            Hooksrepo = new RepositoryHooksRepository(GetAuthProvider());

        }
        protected abstract IRequestProxy GetAuthProvider();

        [Test]
        public void CanGetRepositoryHooks()
        {
            var hooks = Hooksrepo.List("GithubSharp", "RhysC");
            Assert.NotNull(hooks);
            Assert.IsNotEmpty(hooks);
        }
        [Test]
        public void CanGetSingleHook()
        {

        }
        [Test]
        public void CanCreateWebHookAndGetHook()
        {
            var newHook = Hooksrepo.Create("GithubSharp", "RhysC",
                new CreateHookRequest
                {
                    Name = "web",
                    Active = true,
                    Events = new[] { "pull_request" },
                    Config = new Dictionary<string, string> { { "url", "http://localhost:80" }, { "content_type", "json" } }
                });
            Assert.NotNull(newHook);

            var fetchedHook = Hooksrepo.Get("GithubSharp", "RhysC", newHook.Id);
            Assert.NotNull(fetchedHook);
        }
    }
}
