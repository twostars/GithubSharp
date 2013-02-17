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
        /// Note I believe this can only be used with basic authtication provider
        /// </summary>
        /// <returns></returns>
        public CreateAuthorizationTokenResponse CreateNewAuthToken(CreateAuthorizationTokenRequest request)
        {
            LogProvider.LogMessage(string.Format("AuthorizationsRepository.CreateNewAuthToken -  Current Username: '{0}'", AuthenticationProvider.Username));
            return ConsumeJsonUrlAndPostData<CreateAuthorizationTokenRequest, CreateAuthorizationTokenResponse>("authorizations", request);
        }
    }
}