using System.Collections.Generic;
using GithubSharp.Core.Base;
using GithubSharp.Core.Models;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    //TODO - clean up return types - most of these are hangovers from v2. regenerated the dtos
    public class RepositoryRepository : BaseApi//Class name of the year goes to....
    {
        public RepositoryRepository() { }

        protected RepositoryRepository(ILogProvider logProvider, IAuthenticationProvider authenticationProvider)
            : base(logProvider, authenticationProvider) { }

        public IEnumerable<RepositoryFromSearch> Search(string search)
        {
            var url = string.Format("legacy/repos/search/{0}", search);
            var result = ConsumeJsonUrl<Models.Internal.RepositoryCollection<RepositoryFromSearch>>(url);
            return result == null ? null : result.Repositories;
        }

        public Repository Get(string username, string repositoryName)
        {
            var url = string.Format("{0}/{1}/{2}", "repos", username, repositoryName);
            return ConsumeJsonUrl<Repository>(url);
        }

        public Repository[] List(string username)
        {
            var url = string.Format("users/{0}/repos", username);
            return ConsumeJsonUrl<Repository[]>(url);
        }

        public Dictionary<string, int> LanguageBreakDown(string repositoryName, string username)
        {
            var url = string.Format("repos/{0}/{1}/languages", username, repositoryName);
            return ConsumeJsonUrl<Dictionary<string, int>>(url);
        }

        public Tag[] Tags(string repositoryName, string username)
        {
            var url = string.Format("repos/{0}/{1}/tags", username, repositoryName);
            return ConsumeJsonUrl<Tag[]>(url);
        }

        public Branch[] Branches(string repositoryName, string username)
        {
            var url = string.Format("repos/{0}/{1}/branches", username, repositoryName);
            return ConsumeJsonUrl<Branch[]>(url);
        }
    }
}