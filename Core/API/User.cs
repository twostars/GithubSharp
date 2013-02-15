using System.Collections.Generic;
using GithubSharp.Core.Models;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class User : Base.BaseApi
    {
        public User(ICacheProvider cacheProvider, ILogProvider logProvider)
            : base(cacheProvider, logProvider)
        {
        }

        /// <summary>
        /// Search for users
        /// </summary>
        /// <param name="search">search string</param>
        /// <returns>Stripped down details of the users</returns>
        public IEnumerable<UserInCollection> Search(string search)
        {
            LogProvider.LogMessage(string.Format("User.Search - '{0}'", search));
            var url = string.Format("{0}{1}",
                                    "user/search/",
                                    search);
            var result = ConsumeJsonUrl<Models.Internal.UsersCollection<Models.UserInCollection>>(url);
            return result == null ? null : result.Users;
        }

        /// <summary>
        /// Gets extended details for a user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Models.User Get(string username)
        {
            LogProvider.LogMessage(string.Format("User.Get - '{0}'", username));
            var url = string.Format("{0}{1}", "users/", username);
            var result = ConsumeJsonUrl<Models.User>(url);
            return result;
        }

        /// <summary>
        /// Returns a list of followers (string array of user names)
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Follower[] Followers(string username)
        {
            LogProvider.LogMessage(string.Format("User.Followers - '{0}'", username));
            var url = string.Format("users/{0}/followers", username);
            var result = ConsumeJsonUrl<Follower[]>(url);

            return result;
        }


        /// <summary>
        /// Returns a list of watched repositories
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public IEnumerable<Models.Repository> WatchedRepositories(string username)
        {
            LogProvider.LogMessage(string.Format("User.WatchedRepositories - '{0}'", username));
            var url = string.Format("users/{0}/watched", username);
            var result = ConsumeJsonUrl<Models.Repository[]>(url);
            return result;
        }
    }
}
