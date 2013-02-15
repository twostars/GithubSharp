using System.Collections.Generic;
using GithubSharp.Core.Base;
using GithubSharp.Core.Models;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class Repository : BaseApi
    {
        public Repository(ICacheProvider cacheProvider, ILogProvider logProvider)
            : base(cacheProvider, logProvider) { }

        public IEnumerable<RepositoryFromSearch> Search(string search)
        {
            LogProvider.LogMessage(string.Format("Repository.Search - '{0}'", search));
            var url = string.Format("legacy/repos/search/{0}", search);
            var result = ConsumeJsonUrl<Models.Internal.RepositoryCollection<RepositoryFromSearch>>(url);
            return result == null ? null : result.Repositories;
        }

        public Models.Repository Get(string username, string repositoryName)
        {
            LogProvider.LogMessage(string.Format("Repository.Get - Username : '{0}' , RepositoryName : '{1}'", username, repositoryName));
            var url = string.Format("{0}/{1}/{2}", "repos", username, repositoryName);
            var result = ConsumeJsonUrl<Models.Repository>(url);
            return result;
        }

        public Models.Repository[] List(string username)
        {
            LogProvider.LogMessage(string.Format("Repository.List - Username : '{0}'", username));
            var url = string.Format("users/{0}/repos", username);
            var result = ConsumeJsonUrl<Models.Repository[]>(url);
            return result;
        }

        public Dictionary<string, int> LanguageBreakDown(string repositoryName, string username)
        {
            LogProvider.LogMessage(string.Format("Repository.LanguageBreakDown - RepositoryName : '{0}' , Username : '{1}' ", repositoryName, username));
            var url = string.Format("repos/{0}/{1}/languages", username, repositoryName);
            var result = ConsumeJsonUrl<Dictionary<string, int>>(url);
            return result;
        }

        public Tag[] Tags(string repositoryName, string username)
        {
            LogProvider.LogMessage(string.Format("Repository.Tags - RepositoryName : '{0}' , Username : '{1}' ", repositoryName, username));
            var url = string.Format("repos/{0}/{1}/tags", username, repositoryName);
            var result = ConsumeJsonUrl<Tag[]>(url);
            return result;
        }

        public Branch[] Branches(string repositoryName, string username)
        {
            LogProvider.LogMessage(string.Format("Repository.Branches - RepositoryName : '{0}' , Username : '{1}' ", repositoryName, username));
            var url = string.Format("repos/{0}/{1}/branches", username, repositoryName);
            var result = ConsumeJsonUrl<Branch[]>(url);
            return result;
        }
    }
}
