using GithubSharp.Core.Models;

namespace GithubSharp.Core.API
{
    public class CommitsRepository : Base.BaseApi
    {
        public CommitRoot[] CommitsForBranch(string username, string repositoryName, string branchName)
        {
            var url = string.Format("repos/{0}/{1}/commits?sha={2}", username, repositoryName, branchName);
            return ConsumeJsonUrl<CommitRoot[]>(url);
        }

        public CommitRoot[] CommitsForPath(string username, string repositoryName, string branchName, string filePath)
        {
            var url = string.Format("repos/{0}/{1}/commits?sha={2}&path={3}", username, repositoryName, branchName, filePath);
            return ConsumeJsonUrl<CommitRoot[]>(url);
        }

        public SingleFileCommit CommitForSingleFile(string username, string repositoryName, string commitShaId)
        {
            var url = string.Format("repos/{0}/{1}/commits/{2}", username, repositoryName, commitShaId);
            return ConsumeJsonUrl<SingleFileCommit>(url);
        }
    }
}
