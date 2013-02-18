using GithubSharp.Core.Base;
using GithubSharp.Core.Models.Repositories;
using GithubSharp.Core.Models.Users;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class UserRepository : BaseApi
    {
        public UserRepository()
        { }
        protected UserRepository(ILogProvider logProvider, IAuthenticationProvider authenticationProvider)
            : base(logProvider, authenticationProvider)
        { }

        public UserSearchResult[] Search(string search)
        {
            var url = string.Format("legacy/user/search/{0}", search);
            var result = ConsumeJsonUrl<UserSearchResults>(url);
            if (result == null || result.Users == null)
                return new UserSearchResult[] { };
            return result.Users;
        }

        public User Get(string username)
        {
            var url = string.Format("{0}{1}", "users/", username);
            return ConsumeJsonUrl<User>(url);
        }

        public Follower[] Followers(string username)
        {
            var url = string.Format("users/{0}/followers", username);
            return ConsumeJsonUrl<Follower[]>(url);
        }

        public Repository[] WatchedRepositories(string username)
        {
            var url = string.Format("users/{0}/watched", username);
            return ConsumeJsonUrl<Repository[]>(url);
        }
    }
}
