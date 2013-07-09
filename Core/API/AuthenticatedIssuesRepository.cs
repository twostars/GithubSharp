using GithubSharp.Core.Base;
using GithubSharp.Core.Models.Issues;

namespace GithubSharp.Core.API
{
    public class AuthenticatedIssuesRepository : IssuesRepository
    {
        public AuthenticatedIssuesRepository(IRequestProxy requestProxy) : base(requestProxy) { }

        public IssueResponse[] Get()
        {
            return ConsumeJsonUrl<IssueResponse[]>("issues");
        }

        public IssueResponse[] GetForOrganization(string organization)
        {
            return ConsumeJsonUrl<IssueResponse[]>(string.Format("orgs/{0}/issues", organization));
        }

        public IssueResponse Create(string repositoryName, string owner, CreateIssueRequest request)
        {
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
            var url = string.Format("repos/{0}/{1}/issues/{2}", owner, repositoryName, id);
            return ConsumeJsonUrlAndPatchData<IssueUpdateRequest, IssueResponse>(url, request);
        }

        public IssueComment CommentOnIssue(string repositoryName, string owner, int id, string comment)
        {
            var url = string.Format("repos/{0}/{1}/issues/{2}/comments", owner, repositoryName, id);
            return ConsumeJsonUrlAndPostData<IssueCommentCreateRequest, IssueComment>(url, new IssueCommentCreateRequest { Body = comment });
        }
    }
}