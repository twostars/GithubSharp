using System;
using System.Collections.Generic;

namespace GithubSharp.Core.API
{
    public class PullRequestsRepository : Base.BaseApi
    {
        public IEnumerable<Models.PullRequest> List(string username, string repositoryName)
        {
            return List(username, repositoryName, null);
        }

        public Models.PullRequest[] List(string username, string repositoryName, string state)
        {
            var url = string.Format("repos/{0}/{1}/pulls{2}", username, repositoryName, string.IsNullOrEmpty(state) ? "" : "?state=" + state);
            return ConsumeJsonUrl<Models.PullRequest[]>(url);
        }

        public Models.PullRequest GetById(string username, string repositoryName, string id)
        {
            var url = string.Format("repos/{0}/{1}/pulls/{2}", username, repositoryName, id);
            return ConsumeJsonUrl<Models.PullRequest>(url);
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
