using GithubSharp.Core.Models.Authorizations;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class AuthorizationsRepository : Base.BaseApi
    {
        public AuthorizationsRepository(ILogProvider logProvider, IAuthenticationProvider authenticationProvider)
            : base(logProvider, authenticationProvider)
        { }

        /// <summary>
        /// Note I believe this can only be used with basic authtication provider.
        /// Please also note this request is NOT idempotent. Multiple request will create multiple auth tokens!
        /// </summary>
        /// <returns></returns>
        public AuthorizationToken CreateNewAuthToken(CreateAuthorizationTokenRequest request)
        {
            return ConsumeJsonUrlAndPostData<CreateAuthorizationTokenRequest, AuthorizationToken>("authorizations", request);
        }

        public void RemoveAuthToken(int authorizationId)
        {
            ConsumeJsonUrlAndDeleteData<string, string>(string.Format("authorizations/{0}", authorizationId), string.Empty);
        }

        public AuthorizationToken[] GetTokens()
        {
            return ConsumeJsonUrl<AuthorizationToken[]>("authorizations");
        }
    }
}