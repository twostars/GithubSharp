using System.Collections.Generic;
using System.Linq;
using GithubSharp.Core.Models;
using GithubSharp.Core.Models.Issues;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class Issues : Base.BaseApi
    {
        public Issues(ICacheProvider cacheProvider, ILogProvider logProvider)
            : base(cacheProvider, logProvider) { }

        public IssueSearchResult[] Search(string repository, string username, IssueState issueState, string search)
        {
            var state = issueState == IssueState.Open ? "open" : "closed";
            LogProvider.LogMessage(string.Format("Issues.Search - '{0}', repository : '{1}', Username : '{2}', issueState : '{3}'", search,
                              repository, username, state));

            var url = string.Format("legacy/issues/search/{0}/{1}/{2}/{3}",
                                    username,
                                    repository,
                                    state,
                                    search);

            var result = ConsumeJsonUrl<IssueSearchResponse>(url);
            return result != null ? result.Issues : new IssueSearchResult[] { };
        }


        public IssueResponse[] List(string repository, string username, IssueState issueState)
        {
            var state = issueState == IssueState.Open ? "open" : "closed";
            LogProvider.LogMessage(string.Format("Issues.List - repository : '{0}', Username : '{1}', issueState : '{2}'",
                repository, username, state));
            var url = string.Format("repos/{0}/{1}/issues?state={2}", username, repository, state);
            var result = ConsumeJsonUrl<IssueResponse[]>(url);
            return result;
        }

        public IssueResponse View(string repository, string username, int id)
        {
            LogProvider.LogMessage(string.Format("Issues.View - repository: '{0}', Username : '{1}', Id : '{2}'",
                                                 repository, username, id));

            var url = string.Format("repos/{0}/{1}/issues/{2}", username, repository, id);
            var result = ConsumeJsonUrl<IssueResponse>(url);
            return result;
        }


        public IssueLabel[] Labels(string repository, string username, int id)
        {
            LogProvider.LogMessage(string.Format("Issues.Labels - Labels : repository '{0}', Username : '{1}', IssueId : '{2}'",
                                                 repository, username, id));
            var url = string.Format("repos/{0}/{1}/issues/{2}/labels", username, repository, id);
            var result = ConsumeJsonUrl<IssueLabel[]>(url);
            return result;
        }

        public IssueComment[] Comments(string repository, string username, int id)
        {
            LogProvider.LogMessage(string.Format("Issues.Comments - repository: '{0}', Username : '{1}', Id : '{2}'", repository, username, id));
            var url = string.Format("repos/{0}/{1}/issues/{2}/comments", username, repository, id);
            var result = ConsumeJsonUrl<IssueComment[]>(url);
            return result;
        }
    }
}
