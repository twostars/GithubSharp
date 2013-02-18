using System.Linq;
using GithubSharp.Core.API;
using GithubSharp.Core.Services.Implementation;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    //User functions that do not require Auth
    [TestFixture]
    public class UserFixture
    {
        private UserRepository _userRepositoryApi;

        [SetUp]
        public void Setup()
        {
            _userRepositoryApi = new UserRepository(RequestProxyProvider.Basic());
        }

        [Test]
        public void UserCanBeRetrievedByName()
        {
            var user = _userRepositoryApi.Get("rhysc");
            Assert.NotNull(user);
            Assert.AreEqual("Rhys Campbell", user.Name);
            Assert.AreEqual("RhysC", user.Login);
            Assert.AreEqual("https://api.github.com/users/RhysC", user.Url);
        }

        [Test]
        public void CanRetrieveFollower()
        {
            var followers = _userRepositoryApi.Followers("rhysc");
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
            var watchedRepos = _userRepositoryApi.WatchedRepositories("rhysc").ToArray();
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
            var users = _userRepositoryApi.Search("rhysc").ToArray();
            Assert.NotNull(users);
            Assert.IsNotEmpty(users.Where(u => u.Username == "RhysC").ToArray());
            foreach (var user in users)
            {
                Assert.IsNotNullOrEmpty(user.Username);
            }
        }
    }
}
