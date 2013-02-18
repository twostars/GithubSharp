using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class AuthenticatedRepository : RepositoryRepository
    {
        public AuthenticatedRepository(ILogProvider logProvider, IAuthenticationProvider authenticationProvider) :
            base(logProvider, authenticationProvider) { }

        //public Models.Repository SetVisibility(string repositoryName, bool visibility)
        //{
        //    LogProvider.LogMessage("Repository.SetVisibility - RepositoryName : '{0}'", repositoryName);
        //    var url = string.Format("repos/set/{0}/{1}",
        //                            visibility ? "public" : "private",
        //                            repositoryName);

        //    var result = ConsumeJsonUrl<Models.Internal.RepositoryContainer<Models.Repository>>(url);
        //    return result == null ? null : result.Repository;
        //}

        //public IEnumerable<Models.PublicKey> PublicKeys(string repositoryName)
        //{
        //    LogProvider.LogMessage("Repository.PublicKeys - RepositoryName : '{0}'", repositoryName);
        //    var url = string.Format("repos/keys/{0}", repositoryName);

        //    var result = ConsumeJsonUrl<Models.Internal.PublicKeyCollection<Models.PublicKey>>(url);

        //    return result == null ? null : result.PublicKeys.ToArray();
        //}

        //public IEnumerable<Models.PublicKey> AddDeployKeys(string repositoryName, string title, string key)
        //{
        //    LogProvider.LogMessage("Repository.AddDeployKeys - RepositoryName : '{0}'", repositoryName);

        //    var url = string.Format("repos/keys/{0}/add", repositoryName);

        //    var formValues = new NameValueCollection {{"title", title}, {"key", key}};

        //    var result = ConsumeJsonUrlAndPostData<Models.Internal.PublicKeyCollection<Models.PublicKey>>(url, formValues);

        //    return result == null ? null : result.PublicKeys.ToArray();
        //}

        //public IEnumerable<Models.PublicKey> RemovePublicKey(string repositoryName, int id)
        //{
        //    LogProvider.LogMessage(string.Format("Repository.RemovePublicKey - RepositoryName : '{0}' , id : '{1}' ", repositoryName, id));
        //    var url = string.Format("repos/keys/{0}/remove", repositoryName);

        //    var formValues = new NameValueCollection {{"id", id.ToString()}};

        //    var result = ConsumeJsonUrlAndPostData<Models.Internal.PublicKeyCollection<Models.PublicKey>>(url, formValues);

        //    return result == null ? null : result.PublicKeys.ToArray();
        //}

        //public string[] GetCollaborators(string username, string repositoryName)
        //{
        //    LogProvider.LogMessage(string.Format("Repository.GetCollaborators - RepositoryName : '{0}' , Username : '{1}'", repositoryName, username));

        //    var url = string.Format("repos/show/{0}/{1}/collaborators", username, repositoryName);

        //    var result = ConsumeJsonUrl<Models.Internal.CollaboratorsCollection>(url);

        //    return result == null ? null : result.Collaborators.ToArray();
        //}

        //public string[] AddCollaborator(string repositoryName, string username)
        //{
        //    LogProvider.LogMessage(string.Format("Repository.AddCollaborator - RepositoryName : '{0}' , Username : '{1}' ", repositoryName, username));
        //    var url = string.Format("repos/collaborators/{0}/add/{1}", repositoryName, username);

        //    var formValues = new NameValueCollection();

        //    var result = ConsumeJsonUrlAndPostData<Models.Internal.CollaboratorsCollection>(url, formValues);

        //    return result == null ? null : result.Collaborators.ToArray();
        //}

        //public string[] RemoveCollaborator(string repositoryName, string username)
        //{
        //    LogProvider.LogMessage(string.Format("Repository.RemoveCollaborator - RepositoryName : '{0}' , Username : '{1}' ", repositoryName, username));

        //    var url = string.Format("repos/collaborators/{0}/remove/{1}", repositoryName, username);

        //    var formValues = new NameValueCollection();

        //    var result = ConsumeJsonUrlAndPostData<Models.Internal.CollaboratorsCollection>(url, formValues);

        //    return result == null ? null : result.Collaborators.ToArray();
        //}

        //public Models.Repository Watch(string username, string repositoryName)
        //{
        //    LogProvider.LogMessage(string.Format("Repository.Watch - Username : '{0}' , RepositoryName : '{1}'", username, repositoryName));
        //    var url = string.Format("repos/watch/{0}/{1}",
        //                            username,
        //                            repositoryName);

        //    var result = ConsumeJsonUrl<Models.Internal.RepositoryContainer<Models.Repository>>(url);

        //    return result == null ? null : result.Repository;
        //}

        //public Models.Repository Unwatch(string username, string repositoryName)
        //{
        //    LogProvider.LogMessage(string.Format("Repository.Unwatch - Username : '{0}' , RepositoryName : '{1}'", username, repositoryName));
        //    var url = string.Format("repos/unwatch/{0}/{1}",
        //                                       username,
        //                                       repositoryName);

        //    var result = ConsumeJsonUrl<Models.Internal.RepositoryContainer<Models.Repository>>(url);

        //    return result == null ? null : result.Repository;
        //}

        //public Models.Repository Fork(string username, string repositoryName)
        //{
        //    LogProvider.LogMessage(string.Format("Repository.Fork - Username : '{0}' , RepositoryName : '{1}'", username, repositoryName));
        //    var url = string.Format("repos/fork/{0}/{1}",
        //                            username,
        //                            repositoryName);

        //    var result = ConsumeJsonUrl<Models.Internal.RepositoryContainer<Models.Repository>>(url);

        //    return result == null ? null : result.Repository;
        //}

        //public Models.Repository Create(string repositoryName, string description, string homePage, bool @public)
        //{
        //    LogProvider.LogMessage(string.Format("Repository.Create - RepositoryName : '{0}' , Description : '{1}' , HomePage : '{2}', Public : '{3}'",
        //                                         repositoryName,
        //                                         description,
        //                                         homePage,
        //                                         @public));
        //    var url = "repos/create";

        //    var formValues = new NameValueCollection();
        //    if (string.IsNullOrEmpty(repositoryName))
        //    {
        //        var error = new NullReferenceException("RepositoryName was null or empty");
        //        if (LogProvider.HandleAndReturnIfToThrowError(error))
        //            throw error;
        //        return null;
        //    }
        //    formValues.Add("name", repositoryName);

        //    if (!string.IsNullOrEmpty(description))
        //        formValues.Add("description", description);
        //    if (!string.IsNullOrEmpty(homePage))
        //        formValues.Add("homepage", homePage);

        //    formValues.Add("public", (@public ? 1 : 0).ToString());

        //    var result = ConsumeJsonUrlAndPostData<Models.Internal.RepositoryContainer<Models.Repository>>(url, formValues);

        //    return result == null ? null : result.Repository;
        //}

        //public bool Delete(string repositoryName)
        //{
        //    LogProvider.LogMessage("Repository.Delete - RepositoryName : '{0}'", repositoryName);
        //    var url = "repos/delete/" + repositoryName;

        //    var result = ConsumeJsonUrlAndPostData<Models.Internal.RepositoryDelete>(url);

        //    if (result == null)
        //        return false;

        //    var formValues = new NameValueCollection {{"delete_token", result.DeleteToken}};

        //    var status = ConsumeJsonUrlAndPostData<Models.Internal.RepositoryDeleted>(url, formValues);

        //    return status != null && status.Status == "deleted";
        //}
    }
}