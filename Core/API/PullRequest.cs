using System;
using System.Collections.Generic;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class PullRequest : Base.BaseApi
    {
        public PullRequest(ICacheProvider cacheProvider, ILogProvider logProvider) : base(cacheProvider, logProvider) { }

        public IEnumerable<Models.PullRequest> List(string username, string repositoryName)
        {
            return List(username, repositoryName, null);
        }

        public IEnumerable<Models.PullRequest> List(string username, string repositoryName, string state)
        {
            LogProvider.LogMessage(string.Format("PullRequest.List - {0} - {1} - {2}", username, repositoryName, state));
            var url = string.Format("repos/{0}/{1}/pulls{2}",
                                    username,
                                    repositoryName,
                                    string.IsNullOrEmpty(state) ? "" : "?state=" + state);
            var result = ConsumeJsonUrl<Models.PullRequest[]>(url);
            return result;
        }

        public Models.PullRequest GetById(string username, string repositoryName, string id)
        {
            LogProvider.LogMessage(string.Format("PullRequest.GetById - {0} - {1} - {2}", username, repositoryName, id));
            var url = string.Format("repos/{0}/{1}/pulls/{2}", username, repositoryName, id);
            var result = ConsumeJsonUrl<Models.PullRequest>(url);
            return result;
        }

        public Models.PullRequest Create(string username, string repositoryName, string baseRef, string headRef, string title, string body)
        {
            throw new NotImplementedException("Not yet inmplemented for V3");
            //LogProvider.LogMessage(string.Format("PullRequest.Create - {0} - {1} - {2} - {3} - {4}", username, repositoryName, baseRef, headRef, title));
            //if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(repositoryName) || string.IsNullOrEmpty(baseRef) || string.IsNullOrEmpty(headRef) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(body))
            //    return null;

            //var url = string.Format("pulls/{0}/{1}", username, repositoryName);

            //var formValues = new NameValueCollection();
            //formValues.Add("pull[base]", baseRef);
            //formValues.Add("pull[head]", headRef);
            //formValues.Add("pull[title]", title);
            //formValues.Add("pull[body]", body);

            //var result = ConsumeJsonUrlAndPostData<Models.Internal.PullRequestContainer>(url, formValues);

            //return result != null ? result.PullRequest : null;
        }
    }
}
