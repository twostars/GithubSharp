using System.Collections.Generic;
using GithubSharp.Core.Services;
using GithubSharp.Core.Models;

namespace GithubSharp.Core.API
{
    public class Commits : Base.BaseApi
    {
        public Commits(ICacheProvider cacheProvider, ILogProvider logProvider) :
            base(cacheProvider, logProvider) { }

        public CommitRoot[] CommitsForBranch(string username, string repositoryName, string branchName)
        {
            LogProvider.LogMessage(string.Format("Commits.CommitsForBranch - Username : '{0}', RepositoryName : '{1}', Branch : '{2}'",
                username,
                repositoryName,
                branchName));

            var url = string.Format("repos/{0}/{1}/commits?sha={2}", username, repositoryName, branchName);
            var result = ConsumeJsonUrl<CommitRoot[]>(url);
            return result;
        }


        public CommitRoot[] CommitsForPath(string username, string repositoryName, string branchName, string filePath)
        {
            LogProvider.LogMessage(string.Format("Commits.CommitsForFile - Username : '{0}', RepositoryName : '{1}', Branch : '{2}', Path : '{3}'",
                                                username, repositoryName, branchName, filePath));

            var url = string.Format("repos/{0}/{1}/commits?sha={2}&path={3}", username, repositoryName, branchName, filePath);
            var result = ConsumeJsonUrl<CommitRoot[]>(url);
            return result;
        }

        public SingleFileCommit CommitForSingleFile(string username, string repositoryName, string commitShaId)
        {
            LogProvider.LogMessage(string.Format("Commits.CommitForSingleFile - Username : '{0}', RepositoryName : '{1}', CommitShaId : '{2}'",
                username,
                repositoryName,
                commitShaId));

            var url = string.Format("repos/{0}/{1}/commits/{2}", username, repositoryName, commitShaId);
            var result = ConsumeJsonUrl<SingleFileCommit>(url);
            return result;
        }
    }
}
