using System.Collections.Specialized;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class AuthenticatedIssues : Issues
    {
        public AuthenticatedIssues(ICacheProvider CacheProvider, ILogProvider LogProvider)
            : base(CacheProvider, LogProvider) { }

        public Models.Issue Open(string RepositoryName, string Username, string Title, string Body)
        {
            LogProvider.LogMessage(string.Format("Issues.Open - repository: '{0}', Username : '{1}', Title : '{2}'", RepositoryName, Username, Title));

            Authenticate();

            //var url = string.Format("issues/open/{0}/{1}",
            //   Username,
            var url = string.Format("issues/open/{0}",
                                    RepositoryName);

            var formValues = new NameValueCollection();
            formValues.Add("title", Title);
            formValues.Add("body", Body);

            var result = ConsumeJsonUrlAndPostData<Models.Internal.IssueContainer>(url, formValues);

            return result != null ? result.Issue : null;
        }

        public Models.Issue ReOpen(string RepositoryName, string Username, int Id)
        {
            LogProvider.LogMessage(string.Format("Issues.ReOpen - repository: '{0}', Username : '{1}', Id : '{2}'", RepositoryName, Username, Id));

            Authenticate();

            //var url = string.Format("issues/reopen/{0}/{1}/{2}",
            //   Username,
            var url = string.Format("issues/reopen/{0}/{1}",
                                    RepositoryName,
                                    Id);

            var formValues = new NameValueCollection();

            var result = ConsumeJsonUrlAndPostData<Models.Internal.IssueContainer>(url, formValues);

            return result != null ? result.Issue : null;
        }

        public Models.Issue Close(string RepositoryName, string Username, int Id)
        {
            LogProvider.LogMessage(string.Format("Issues.Close - repository: '{0}', Username : '{1}', Id : '{2}'", RepositoryName, Username, Id));

            Authenticate();

            //var url = string.Format("issues/close/{0}/{1}/{2}",
            //   Username,
            var url = string.Format("issues/close/{0}/{1}",
                                    RepositoryName,
                                    Id);

            var formValues = new NameValueCollection();

            var result = ConsumeJsonUrlAndPostData<Models.Internal.IssueContainer>(url, formValues);

            return result != null ? result.Issue : null;
        }

        public Models.Issue Edit(string RepositoryName, string Username, int Id, string Title, string Body)
        {
            LogProvider.LogMessage(string.Format("Issues.Edit - repository: '{0}', Username : '{1}', Title : '{2}', Id : '{3}'", RepositoryName, Username, Title, Id));

            Authenticate();

            //var url = string.Format("issues/edit/{0}/{1}/{2}",
            //   Username,
            var url = string.Format("issues/edit/{0}/{1}",
                                    RepositoryName,
                                    Id);

            var formValues = new NameValueCollection();
            formValues.Add("title", Title);
            formValues.Add("body", Body);

            var result = ConsumeJsonUrlAndPostData<Models.Internal.IssueContainer>(url, formValues);

            return result != null ? result.Issue : null;
        }

        public string[] AddLabel(string RepositoryName, string Username, int Id, string Label)
        {
            LogProvider.LogMessage(string.Format("Issues.AddLabel - repository: '{0}', Username : '{1}', Label : '{2}', Id : '{3}'", RepositoryName, Username, Label, Id));

            Authenticate();

            //            var url = string.Format("issues/label/add/{0}/{1}/{2}/{3}",
            //               Username,
            var url = string.Format("issues/label/add/{0}/{1}/{2}",
                                    RepositoryName,
                                    Label,
                                    Id);

            var formValues = new NameValueCollection();

            var result = ConsumeJsonUrlAndPostData<Models.Internal.LabelsCollection>(url, formValues);

            return result != null ? result.Labels : null;
        }

        public string[] RemoveLabel(string RepositoryName, string Username, int Id, string Label)
        {
            LogProvider.LogMessage(string.Format("Issues.RemoveLabel - repository: '{0}', Username : '{1}', Label : '{2}', Id : '{3}'", RepositoryName, Username, Label, Id));

            Authenticate();

            //            var url = string.Format("issues/label/remove/{0}/{1}/{2}/{3}",
            //               Username,
            var url = string.Format("issues/label/remove/{0}/{1}/{2}",
                                    RepositoryName,
                                    Label,
                                    Id);

            var formValues = new NameValueCollection();

            var result = ConsumeJsonUrlAndPostData<Models.Internal.LabelsCollection>(url, formValues);

            return result != null ? result.Labels : null;
        }

        public bool CommentOnIssue(string RepositoryName, string Username, int Id, string Comment)
        {
            LogProvider.LogMessage(string.Format("Issues.CommentOnIssue - repository: '{0}', Username : '{1}', Id : '{2}'", RepositoryName, Username, Id));

            Authenticate();

            //            var url = string.Format("issues/comment/{0}/{1}/{2}",
            //               Username,
            var url = string.Format("issues/comment/{0}/{1}",
                                    RepositoryName,
                                    Id);

            var formValues = new NameValueCollection();
            formValues.Add("comment", Comment);

            var result = ConsumeJsonUrlAndPostData<Models.Internal.CommentSavedContainer>(url, formValues);

            return result != null && result.Comment != null ? !string.IsNullOrEmpty(result.Comment.Id) : false;
        }


    }
}