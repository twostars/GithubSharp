using GithubSharp.Core.Base;
using GithubSharp.Core.Models.Repositories;

namespace GithubSharp.Core.API
{
    public class CommitsRepository : BaseApi
    {
        public CommitsRepository(IRequestProxy requestProxy) : base(requestProxy)
        {
        }

        public Commit[] CommitsForBranch(string username, string repositoryName, string branchName)
        {
            var url = string.Format("repos/{0}/{1}/commits?sha={2}", username, repositoryName, branchName);
            return ConsumeJsonUrl<Commit[]>(url);
        }

        public Commit[] CommitsForPath(string username, string repositoryName, string branchName, string filePath)
        {
            var url = string.Format("repos/{0}/{1}/commits?sha={2}&path={3}", username, repositoryName, branchName, filePath);
            return ConsumeJsonUrl<Commit[]>(url);
        }

        public CommitDetails CommitForSingleFile(string username, string repositoryName, string commitShaId)
        {
            var url = string.Format("repos/{0}/{1}/commits/{2}", username, repositoryName, commitShaId);
            return ConsumeJsonUrl<CommitDetails>(url);
        }
    }
}