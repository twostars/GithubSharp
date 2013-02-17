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
            return Edit(repositoryName, owner, id, new IssueUpdateRequest { State = "closed" });
        }

        public IssueResponse ReOpen(string repositoryName, string owner, int id)
        {
            return Edit(repositoryName, owner, id, new IssueUpdateRequest { State = "open" });
        }

        public IssueResponse Edit(string repositoryName, string owner, int id, IssueUpdateRequest request)
        {
            LogProvider.LogMessage(string.Format("IssuesRepository.Edit - repository: '{0}', Owner : '{1}', Id : '{2}'", repositoryName, owner, id), request);
            var url = string.Format("repos/{0}/{1}/issues/{2}", owner, repositoryName, id);
            return ConsumeJsonUrlAndPostData<IssueUpdateRequest, IssueResponse>(url, request);
        }

        public IssueComment CommentOnIssue(string repositoryName, string owner, int id, string comment)
        {
            LogProvider.LogMessage(string.Format("IssuesRepository.CommentOnIssue - repository: '{0}', Username : '{1}', Id : '{2}'", repositoryName, owner, id));
            var url = string.Format("repos/{0}/{1}/issues/{2}/comments", owner, repositoryName, id);
            return ConsumeJsonUrlAndPostData<IssueCommentCreateRequest, IssueComment>(url, new IssueCommentCreateRequest { Body = comment });
        }
    }
}