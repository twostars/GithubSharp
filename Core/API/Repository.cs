using System.Collections.Generic;
using System.Linq;
using GithubSharp.Core.Base;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class Repository : BaseApi
    {
        public Repository(ICacheProvider cacheProvider, ILogProvider logProvider)
            : base(cacheProvider, logProvider)
        {
        }

        public IEnumerable<Models.RepositoryFromSearch> Search(string search)
        {
            LogProvider.LogMessage(string.Format("Repository.Search - '{0}'", search));

            var url = string.Format("{0}{1}",
                                    "repos/search/",
                                    search);

            var result = ConsumeJsonUrl<Models.Internal.RepositoryCollection<Models.RepositoryFromSearch>>(url);

            return result == null ? null : result.Repositories;
        }

        public Models.Repository Get(string username, string repositoryName)
        {
            LogProvider.LogMessage(string.Format("Repository.Get - Username : '{0}' , RepositoryName : '{1}'", username,
                                                 repositoryName));

            var url = string.Format("{0}/{1}/{2}",
                                    "repos",
                                    username,
                                    repositoryName);

            var result = ConsumeJsonUrl<Models.Repository>(url);

            return result;
        }

        public IEnumerable<Models.Repository> List(string username)
        {
            LogProvider.LogMessage(string.Format("Repository.List - Username : '{0}'", username));

            var url = string.Format("{0}{1}",
                                    "repos/show/",
                                    username);

            var result = ConsumeJsonUrl<Models.Internal.RepositoryCollection<Models.Repository>>(url);

            return result == null ? null : result.Repositories;
        }




        public IEnumerable<Models.Repository> Network(string repositoryName, string username)
        {
            LogProvider.LogMessage(string.Format("Repository.Network - RepositoryName : '{0}' , Username : '{1}' ",
                                                 repositoryName, username));

            var url = string.Format("repos/show/{1}/{0}/network", repositoryName, username);

            var result = ConsumeJsonUrl<Models.Internal.RepositoryFromNetworkContainer>(url);

            return result == null ? null : result.Network.ToArray();
        }

        public IEnumerable<Models.Language> LanguageBreakDown(string repositoryName, string username)
        {
            LogProvider.LogMessage(
                string.Format("Repository.LanguageBreakDown - RepositoryName : '{0}' , Username : '{1}' ",
                              repositoryName, username));

            var url = string.Format("repos/show/{1}/{0}/languages", repositoryName, username);

            var result = ConsumeJsonUrl<Models.Internal.LanguagesCollection>(url);

            return result == null
                       ? null
                       : result.Languages.ToList()
                               .Select(p => new Models.Language { Name = p.Key, CalculatedBytes = p.Value })
                               .ToArray();
        }

        public IEnumerable<Models.TagOrBranch> Tags(string repositoryName, string username)
        {
            LogProvider.LogMessage(string.Format("Repository.Tags - RepositoryName : '{0}' , Username : '{1}' ",
                                                 repositoryName, username));

            var url = string.Format("repos/show/{1}/{0}/tags", repositoryName, username);

            var result = ConsumeJsonUrl<Models.Internal.TagCollection>(url);

            return result == null
                       ? null
                       : result.Tags.Dict.ToList()
                               .Select(p => new Models.TagOrBranch { Name = p.Key, Sha = p.Value })
                               .ToArray();
        }

        public Models.TagOrBranch[] Branches(string repositoryName, string username)
        {
            LogProvider.LogMessage(string.Format("Repository.Branches - RepositoryName : '{0}' , Username : '{1}' ",
                                                 repositoryName, username));

            var url = string.Format("repos/show/{1}/{0}/branches", repositoryName, username);

            var result = ConsumeJsonUrl<Models.Internal.BranchesCollection>(url);

            return result == null
                       ? null
                       : result.Branches.Dict.Select(p => new Models.TagOrBranch { Name = p.Key, Sha = p.Value })
                               .ToArray();
        }
    }
}
