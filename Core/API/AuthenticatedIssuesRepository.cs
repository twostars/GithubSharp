using System.Collections.Specialized;
using GithubSharp.Core.Models.Issues;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class AuthenticatedIssuesRepository : IssuesRepository
    {
        public AuthenticatedIssuesRepository(ICacheProvider cacheProvider, ILogProvider logProvider, IAuthenticationProvider authenticationProvider)
            : base(cacheProvider, logProvider, authenticationProvider) { }


        public IssueResponse[] Get()
        {
            LogProvider.LogMessage(string.Format("IssuesRepository.Get -  Current Username: '{0}'", AuthenticationProvider.Username));
            var result = ConsumeJsonUrl<IssueResponse[]>("issues");
            return result;
        }

        public IssueResponse[] GetForOrganization(string organization)
        {
            LogProvider.LogMessage(string.Format("IssuesRepository.Get -  Current Username: '{0}'", AuthenticationProvider.Username));
            var result = ConsumeJsonUrl<IssueResponse[]>(string.Format("orgs/{0}/issues", organization));
            return result;
        }

        public IssueResponse Create(string repositoryName, string owner, CreateIssueRequest request)
        {
            LogProvider.LogMessage(string.Format("IssuesRepository.Create - repository: '{0}', Username : '{1}', Request : '{2}'", repositoryName, owner, request));
            var url = string.Format("repos/{0}/{1}/issues", owner, repositoryName);
            return ConsumeJsonUrlAndPostData<CreateIssueRequest, IssueResponse>(url, request);
        }

        public IssueResponse Close(string repositoryName, string owner, int id)
        {
            LogProvider.LogMessage(string.Format("IssuesRepository.Close - repository: '{0}', Owner : '{1}', Id : '{2}'", repositoryName, owner, id));
            var issueUpdateRequest = new IssueUpdateRequest {State = "closed"};
            
            var url = string.Format("repos/{0}/{1}/issues/{2}", owner, repositoryName, id);
            return ConsumeJsonUrlAndPostData<IssueUpdateRequest,IssueResponse>(url, issueUpdateRequest);
        }

        //public Models.Issue ReOpen(string repositoryName, string username, int id)
        //{
        //    LogProvider.LogMessage(string.Format("IssuesRepository.ReOpen - repository: '{0}', Username : '{1}', Id : '{2}'", repositoryName, username, id));

        //    var url = string.Format("issues/reopen/{0}/{1}",
        //                            repositoryName,
        //                            id);

        //    var formValues = new NameValueCollection();

        //    var result = ConsumeJsonUrlAndPostData<Models.Internal.IssueContainer>(url, formValues);

        //    return result != null ? result.Issue : null;
        //}

        //public Models.Issue Edit(string repositoryName, string username, int id, string title, string body)
        //{
        //    LogProvider.LogMessage(string.Format("IssuesRepository.Edit - repository: '{0}', Username : '{1}', Title : '{2}', Id : '{3}'", repositoryName, username, title, id));

        //    var url = string.Format("issues/edit/{0}/{1}",
        //                            repositoryName,
        //                            id);

        //    var formValues = new NameValueCollection { { "title", title }, { "body", body } };

        //    var result = ConsumeJsonUrlAndPostData<Models.Internal.IssueContainer>(url, formValues);

        //    return result != null ? result.Issue : null;
        //}

        //public string[] AddLabel(string repositoryName, string username, int id, string label)
        //{
        //    LogProvider.LogMessage(string.Format("IssuesRepository.AddLabel - repository: '{0}', Username : '{1}', Label : '{2}', Id : '{3}'", repositoryName, username, label, id));

        //    var url = string.Format("issues/label/add/{0}/{1}/{2}",
        //                            repositoryName,
        //                            label,
        //                            id);

        //    var formValues = new NameValueCollection();

        //    var result = ConsumeJsonUrlAndPostData<Models.Internal.LabelsCollection>(url, formValues);

        //    return result != null ? result.Labels : null;
        //}

        //public string[] RemoveLabel(string repositoryName, string username, int id, string label)
        //{
        //    LogProvider.LogMessage(string.Format("IssuesRepository.RemoveLabel - repository: '{0}', Username : '{1}', Label : '{2}', Id : '{3}'", repositoryName, username, label, id));

        //    var url = string.Format("issues/label/remove/{0}/{1}/{2}",
        //                            repositoryName,
        //                            label,
        //                            id);

        //    var formValues = new NameValueCollection();

        //    var result = ConsumeJsonUrlAndPostData<Models.Internal.LabelsCollection>(url, formValues);

        //    return result != null ? result.Labels : null;
        //}

        //public bool CommentOnIssue(string repositoryName, string username, int id, string comment)
        //{
        //    LogProvider.LogMessage(string.Format("IssuesRepository.CommentOnIssue - repository: '{0}', Username : '{1}', Id : '{2}'", repositoryName, username, id));

        //    var url = string.Format("issues/comment/{0}/{1}",
        //                            repositoryName,
        //                            id);

        //    var formValues = new NameValueCollection { { "comment", comment } };

        //    var result = ConsumeJsonUrlAndPostData<Models.Internal.CommentSavedContainer>(url, formValues);

        //    return result != null && result.Comment != null && !string.IsNullOrEmpty(result.Comment.Id);
        //}
    }
}