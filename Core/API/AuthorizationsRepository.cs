using GithubSharp.Core.Models.Authorizations;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class AuthorizationsRepository : Base.BaseApi
    {
        public AuthorizationsRepository(ICacheProvider cacheProvider, ILogProvider logProvider,
                                        IAuthenticationProvider authenticationProvider)
            : base(cacheProvider, logProvider, authenticationProvider)
        {
        }

        /// <summary>
        /// Note I believe this can only be used with basic authtication provider.
        /// Please also note this request is NOT idempotent. Multiple request will create multiple auth tokens!
        /// </summary>
        /// <returns></returns>
        public CreateAuthorizationTokenResponse CreateNewAuthToken(CreateAuthorizationTokenRequest request)
        {
            LogProvider.LogMessage(string.Format("AuthorizationsRepository.CreateNewAuthToken -  Current Username: '{0}'", AuthenticationProvider.Username));
            return ConsumeJsonUrlAndPostData<CreateAuthorizationTokenRequest, CreateAuthorizationTokenResponse>("authorizations", request);
        }

        public void RemoveAuthToken(int authorizationId)
        {
            LogProvider.LogMessage(string.Format("AuthorizationsRepository.CreateNewAuthToken -  Current Username: '{0}'", AuthenticationProvider.Username));
            ConsumeJsonUrlAndDeleteData<string, string>(string.Format("authorizations/{0}", authorizationId), string.Empty);
        }

        public object[] GetTokens()
        {
            throw new System.NotImplementedException();
        }
    }
}