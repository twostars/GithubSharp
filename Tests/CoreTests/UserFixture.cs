using System.Linq;
using GithubSharp.Core.API;
using GithubSharp.Plugins.LogProviders.NullLogger;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    //User functions that do not require Auth
    [TestFixture]
    public class UserFixture
    {
        private User _userApi;

        [SetUp]
        public void Setup()
        {
            _userApi = new User(new BasicCacher.BasicCacher(), new NullLogger());
        }

        [Test]
        public void UserCanBeRetrievedByName()
        {
            var user = _userApi.Get("rhysc");
            Assert.NotNull(user);
            Assert.AreEqual("Rhys Campbell", user.Name);
            Assert.AreEqual("RhysC", user.Login);
            Assert.AreEqual("https://api.github.com/users/RhysC", user.Url);
        }

        [Test]
        public void CanRetrieveFollower()
        {
            var followers = _userApi.Followers("rhysc");
            Assert.NotNull(followers);
            Assert.IsNotEmpty(followers);//a sad day when this fails ;)
            foreach (var follower in followers)
            {
                Assert.IsNotNullOrEmpty(follower.Login);//at least have a login!
            }
        }

        [Test]
        public void CanRetrieveUsersWatchedRepos()
        {
            var watchedRepos = _userApi.WatchedRepositories("rhysc").ToArray();
            Assert.NotNull(watchedRepos);
            Assert.IsNotEmpty(watchedRepos);
            foreach (var repo in watchedRepos)
            {
                Assert.IsNotNullOrEmpty(repo.FullName);
            }
        }

        [Test]
        public void CanSearchForUsers()
        {
            var users = _userApi.Search("rhysc").ToArray();
            Assert.NotNull(users);
            Assert.IsNotEmpty(users.Where(u => u.UserName == "RhysC").ToArray());
            foreach (var user in users)
            {
                Assert.IsNotNullOrEmpty(user.UserName);
            }
        }
    }
}
