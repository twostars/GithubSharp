using System.Collections.Generic;
using GithubSharp.Core.Base;
using GithubSharp.Core.Models.Repositories;

namespace GithubSharp.Core.API
{
    public class RepositoryRepository : BaseApi//Class name of the year goes to....
    {
        public RepositoryRepository(IRequestProxy requestProxy) : base(requestProxy) { }

        public RepositorySearchResult[] Search(string search)
        {
            var url = string.Format("legacy/repos/search/{0}", search);
            var result = ConsumeJsonUrl<RepositoriesSearchResult>(url);
            return result == null ? new RepositorySearchResult[] { } : result.Repositories;
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

        public TagOrBranch[] Tags(string repositoryName, string username)
        {
            var url = string.Format("repos/{0}/{1}/tags", username, repositoryName);
            return ConsumeJsonUrl<TagOrBranch[]>(url);
        }

        public TagOrBranch[] Branches(string repositoryName, string username)
        {
            var url = string.Format("repos/{0}/{1}/branches", username, repositoryName);
            return ConsumeJsonUrl<TagOrBranch[]>(url);
        }

        public BranchDetails Branches(string repositoryName, string owner, string branch)
        {
            var url = string.Format("repos/{0}/{1}/branches/{2}", owner, repositoryName, branch);
            return ConsumeJsonUrl<BranchDetails>(url);
        }
    }
}