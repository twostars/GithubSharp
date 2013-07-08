using GithubSharp.Core.Base;
using GithubSharp.Core.Models.Repositories.Hooks;

namespace GithubSharp.Core.API
{
    public class RepositoryHooksRepository : BaseApi
    {
        public RepositoryHooksRepository(IRequestProxy requestProxy) : base(requestProxy) { }

        public Hook[] List(string repositoryName, string owner)
        {
            var url = string.Format("{0}/{1}/{2}/hooks", "repos", owner, repositoryName);
            AppendPerPageLimit(ref url); 
            return ConsumeJsonUrl<Hook[]>(url);
        }

        public Hook Get(string repositoryName, string owner, int id)
        {
            var url = string.Format("{0}/{1}/{2}/hooks/{3}", "repos", owner, repositoryName, id);
            return ConsumeJsonUrl<Hook>(url);
        }

        public Hook Create(string repositoryName, string owner, CreateHookRequest createHookRequest)
        {
            var url = string.Format("{0}/{1}/{2}/hooks", "repos", owner, repositoryName);
            return ConsumeJsonUrlAndPostData<CreateHookRequest, Hook>(url, createHookRequest);
        }
    }
}
