using GithubSharp.Core.Base;
using GithubSharp.Core.Models.Issues;

namespace GithubSharp.Core.API
{
    public class IssuesRepository : BaseApi
    {
        public IssuesRepository(IRequestProxy requestProxy) : base(requestProxy) { }

        protected string GetPathByDefault(string repository, string username, string format, params object[] formatParams)
        {
            return string.Format("repos/{0}/{1}/issues{2}", username, repository, string.Format(format, formatParams));
        }

        public IssueSearchResult[] Search(string repository, string owner, IssueState issueState, string search)
        {
            var state = issueState == IssueState.Open ? "open" : "closed";
            var url = string.Format("legacy/issues/search/{0}/{1}/{2}/{3}",
                                     owner,
                                     repository,
                                     state,
                                     search);

            AppendPerPageLimit(ref url);

            var result = ConsumeJsonUrl<IssueSearchResponse>(url);
            return result != null ? result.Issues : new IssueSearchResult[] { };
        }

        public IssueResponse[] List(string repository, string owner, IssueState issueState)
        {
            var state = issueState == IssueState.Open ? "open" : "closed";
            var url = GetPathByDefault(repository, owner, "?state={0}", state);
            AppendPerPageLimit(ref url);
            return ConsumeJsonUrl<IssueResponse[]>(url);
        }

        public IssueResponse View(string repository, string owner, int id)
        {
            var url = GetPathByDefault(repository, owner, "/{0}", id);
            return ConsumeJsonUrl<IssueResponse>(url);
        }

        public IssueLabel[] Labels(string repository, string owner, int id)
        {
            var url = GetPathByDefault(repository, owner, "/{0}/labels", id);
            return ConsumeJsonUrl<IssueLabel[]>(url);
        }

        public IssueComment[] Comments(string repository, string owner, int id)
        {
            var url = GetPathByDefault(repository, owner, "/{0}/comments", id);
            AppendPerPageLimit(ref url);
            return ConsumeJsonUrl<IssueComment[]>(url);
        }
    }

    public enum IssueState
    {
        Open,
        Closed
    }
}
