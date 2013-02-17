using GithubSharp.Core.Models.Users;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class AuthenticatedUserRepository : UserRepository
    {
        public AuthenticatedUserRepository(ICacheProvider cacheProvider, ILogProvider logProvider, IAuthenticationProvider authenticationProvider)
            : base(cacheProvider, logProvider, authenticationProvider) { }

        protected string CurrentUsername
        {
            get { return AuthenticationProvider.Username; }
        }

        public AuthenticatedUser Get()
        {
            LogProvider.LogMessage(string.Format("UserRepository.Get (Authenticated) - '{0}'", CurrentUsername));
            return ConsumeJsonUrl<AuthenticatedUser>("user");
        }

        public PublicKey[] PublicKeys()
        {
            LogProvider.LogMessage("UserRepository.PublicKeys");
            return ConsumeJsonUrl<PublicKey[]>("user/keys");
        }

        public string[] Emails()
        {
            LogProvider.LogMessage("UserRepository.Emails");
            return ConsumeJsonUrl<string[]>("user/emails");
        }

        public string[] AddEmails(string[] emails)
        {
            LogProvider.LogMessage("UserRepository.AddEmails {0}", string.Join(",", emails));
            return ConsumeJsonUrlAndPostData<string[], string[]>("user/emails", emails);
        }

        public void RemoveEmail(string[] emails)
        {
            LogProvider.LogMessage("UserRepository.RemoveEmails {0}", string.Join(",", emails));
            ConsumeJsonUrlAndDeleteData<string[], string>("user/emails", emails);//return type not used. This is is a no content response
        }



        ///// <summary>
        ///// Updates a users details
        /////<para>Needs to bee authenticated (with a valid Github UserRepository)</para>
        ///// </summary>
        ///// <param name="Name"></param>
        ///// <param name="Email"></param>
        ///// <param name="Blog"></param>
        ///// <param name="Company"></param>
        ///// <param name="Location"></param>
        ///// <returns></returns>
        //public Models.UserAuthenticated Update(
        //    string Name,
        //    string Email,
        //    string Blog,
        //    string Company,
        //    string Location)
        //{
        //    LogProvider.LogMessage(string.Format("UserRepository.Update (Authenticated)\nName: '{0}' Email : '{1}' Blog : '{2}' Company : '{3}' Location : '{4}'",
        //                                         Name,
        //                                         Email,
        //                                         Blog,
        //                                         Company,
        //                                         Location));

        //    var url = string.Format("user/show/{0}", CurrentUsername);

        //    var formValues = new NameValueCollection();

        //    if (Name != null)//an empty string is ok
        //        formValues.Add("name", Name);
        //    if (Email != null)//an empty string is ok
        //        formValues.Add("email", Email);
        //    if (Blog != null)//an empty string is ok
        //        formValues.Add("blog", Blog);
        //    if (Company != null)//an empty string is ok
        //        formValues.Add("company", Company);
        //    if (Location != null)//an empty string is ok
        //        formValues.Add("location", Location);

        //    if (formValues.Count == 0)
        //    {
        //        var error = new Exception("UserRepository.Update : At least one parameter needs to either be and empty string or with content, all parameters were null");
        //        if (LogProvider.HandleAndReturnIfToThrowError(error))
        //            throw error;

        //        return null;
        //    }

        //    var result = ConsumeJsonUrlAndPostData<Models.Internal.UserContainer<Models.UserAuthenticated>>(url, formValues);

        //    return result == null ? null : result.UserRepository;
        //}

        ///// <summary>
        ///// Follow user
        /////<para>Needs to bee authenticated (with a valid Github UserRepository)</para>
        ///// </summary>
        ///// <param name="Username"></param>
        ///// <returns></returns>
        //public string[] Follow(string Username)
        //{
        //    LogProvider.LogMessage(string.Format("UserRepository.Follow - '{0}'", Username));

        //    var url = string.Format("user/follow/{0}", Username);

        //    var result = ConsumeJsonUrlAndPostData<Models.Internal.UsersCollection<string>>(url);

        //    return result == null ? null : result.Users.ToArray();
        //}


        ///// <summary>
        ///// UnFollow user
        /////<para>Needs to bee authenticated (with a valid Github UserRepository)</para>
        ///// 
        ///// <para>Note: Does not work <see cref="http://github.com/develop/develop.github.com/issues#issue/39"/></para>
        ///// </summary>
        ///// <param name="Username"></param>
        ///// <returns></returns>
        //public string[] UnFollow(string Username)
        //{
        //    LogProvider.LogMessage(string.Format("UserRepository.UnFollow - '{0}'", Username));

        //    var url = string.Format("{0}{1}",
        //                            "user/unfollow/",
        //                            Username);
        //    var result = ConsumeJsonUrlAndPostData<Models.Internal.UsersCollection<string>>(url);

        //    return result == null ? null : result.Users.ToArray();
        //}



        ///// <summary>
        ///// Add a public key
        /////<para>Needs to bee authenticated (with a valid Github UserRepository)</para>
        ///// </summary>
        ///// <param name="PublicKey"></param>
        ///// <returns></returns>
        //public IEnumerable<Models.PublicKey> AddPublicKey(Models.PublicKey PublicKey)
        //{
        //    LogProvider.LogMessage(string.Format("UserRepository.AddPublicKey - Title : '{0}' Key : {1}", PublicKey.Title, PublicKey.Id));

        //    var url = "user/key/add";

        //    var formValues = new NameValueCollection();
        //    formValues.Add("title", PublicKey.Title);
        //    formValues.Add("key", PublicKey.Key);

        //    var result = ConsumeJsonUrlAndPostData<Models.Internal.PublicKeyCollection<Models.PublicKey>>(url, formValues);

        //    return result == null ? null : result.PublicKeys.ToArray();
        //}

        ///// <summary>
        ///// Removes a public key
        /////<para>Needs to bee authenticated (with a valid Github UserRepository)</para>
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <returns></returns>
        //public IEnumerable<Models.PublicKey> RemovePublicKey(int Id)
        //{
        //    LogProvider.LogMessage(string.Format("UserRepository.RemovePublicKey - id : '{0}' ", Id));

        //    var url = "user/key/remove";

        //    var formValues = new NameValueCollection();
        //    formValues.Add("id", Id.ToString());

        //    var result = ConsumeJsonUrlAndPostData<Models.Internal.PublicKeyCollection<Models.PublicKey>>(url, formValues);

        //    return result == null ? null : result.PublicKeys.ToArray();
        //}





    }
}