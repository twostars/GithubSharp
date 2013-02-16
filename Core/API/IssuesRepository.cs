using GithubSharp.Core.Models;
using GithubSharp.Core.Models.Issues;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class IssuesRepository : Base.BaseApi
    {
        public IssuesRepository(ICacheProvider cacheProvider, ILogProvider logProvider)
            : base(cacheProvider, logProvider) { }

        protected IssuesRepository(ICacheProvider cacheProvider, ILogProvider logProvider, IAuthenticationProvider authenticationProvider)
            : base(cacheProvider, logProvider, authenticationProvider) { }


        protected string GetPathByDefault(string repository, string username, string format, params object[] formatParams)
        {
            return string.Format("repos/{0}/{1}/issues{2}", username, repository, string.Format(format, formatParams));
        }

        public IssueSearchResult[] Search(string repository, string owner, IssueState issueState, string search)
        {
            var state = issueState == IssueState.Open ? "open" : "closed";
            LogProvider.LogMessage(string.Format("IssuesRepository.Search - '{0}', repository : '{1}', Username : '{2}', issueState : '{3}'", search,
                              repository, owner, state));

            var url = string.Format("legacy/issues/search/{0}/{1}/{2}/{3}",
                                    owner,
                                    repository,
                                    state,
                                    search);

            var result = ConsumeJsonUrl<IssueSearchResponse>(url);
            return result != null ? result.Issues : new IssueSearchResult[] { };
        }

        public IssueResponse[] List(string repository, string owner, IssueState issueState)
        {
            var state = issueState == IssueState.Open ? "open" : "closed";
            LogProvider.LogMessage(string.Format("IssuesRepository.List - repository : '{0}', Owner : '{1}', issueState : '{2}'",
                repository, owner, state));
            var url = GetPathByDefault(repository, owner, "?state={0}", state);
            var result = ConsumeJsonUrl<IssueResponse[]>(url);
            return result;
        }

        public IssueResponse View(string repository, string owner, int id)
        {
            LogProvider.LogMessage(string.Format("IssuesRepository.View - repository: '{0}', Owner : '{1}', Id : '{2}'", repository, owner, id));
            var url = GetPathByDefault(repository, owner, "/{0}", id);
            var result = ConsumeJsonUrl<IssueResponse>(url);
            return result;
        }

        public IssueLabel[] Labels(string repository, string owner, int id)
        {
            LogProvider.LogMessage(string.Format("IssuesRepository.Labels - Labels : repository '{0}', Owner : '{1}', IssueId : '{2}'",
                                                 repository, owner, id));
            var url = GetPathByDefault(repository, owner, "/{0}/labels", id);
            var result = ConsumeJsonUrl<IssueLabel[]>(url);
            return result;
        }

        public IssueComment[] Comments(string repository, string owner, int id)
        {
            LogProvider.LogMessage(string.Format("IssuesRepository.Comments - repository: '{0}', Owner : '{1}', Id : '{2}'", repository, owner, id));
            var url = GetPathByDefault(repository, owner, "/{0}/comments", id);
            var result = ConsumeJsonUrl<IssueComment[]>(url);
            return result;
        }
    }

    public enum IssueState
    {
        Open,
        Closed
    }
}
