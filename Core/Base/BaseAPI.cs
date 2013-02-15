using System;
using System.Runtime.Serialization;
using GithubSharp.Core.Services;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace GithubSharp.Core.Base
{
    public abstract class BaseApi : IBaseApi
    {
        private Url _url;

        protected BaseApi(ICacheProvider cache, ILogProvider log)
        {
            CacheProvider = cache;
            LogProvider = log;
        }

        protected ICacheProvider CacheProvider { get; set; }
        protected ILogProvider LogProvider { get; set; }
        private Models.GithubUser CurrentUser { get; set; }

        private Url UrlConsumer
        {
            get { return _url ?? (_url = new Url(CacheProvider, LogProvider)); }
        }
        protected string CurrentUsername { get { return HasUser ? CurrentUser.Name : string.Empty; } }
        private bool HasUser { get { return CurrentUser != null && !string.IsNullOrEmpty(CurrentUser.Name) && !string.IsNullOrEmpty(CurrentUser.APIToken); } }

        public void Authenticate(Models.GithubUser user)
        {
            if (user == null)
                LogProvider.LogMessage("Authenticate => Null user");
            else
                LogProvider.LogMessage("Authenticate => Name : {0}, APIToken : {1}", user.Name, user.APIToken);

            CurrentUser = user;
        }

        public T ConsumeJsonUrlAndPostData<T>(string url) where T : class
        {
            return ConsumeJsonUrlAndPostData<T>(url, new NameValueCollection());
        }

        public T ConsumeJsonUrlAndPostData<T>(string url, NameValueCollection formValues) where T : class
        {
            var result = ConsumeUrlToStringAndPostData(url, formValues);
            if (result == null)
                return null;
            try
            {
                return JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception error)
            {
                if (LogProvider.HandleAndReturnIfToThrowError(error))
                    throw;
                return null;
            }
        }
        
        private string GetAuthenticatedUrl(string urlToUseAuthentication)
        {
            var url = string.Format("{0}{1}{2}",
                urlToUseAuthentication.StartsWith("http") ? urlToUseAuthentication : UrlConsumer.GithubBaseURL,
                urlToUseAuthentication.StartsWith("http") ? "" : urlToUseAuthentication,
                UrlConsumer.GithubAuthenticationQueryString(CurrentUser));
            return url;
        }

        protected string ConsumeUrlToString(string url)
        {
            var authenticationUrl = GetAuthenticatedUrl(url);

            return UrlConsumer.GetStringFromURL(authenticationUrl);
        }
        protected byte[] ConsumeUrlToBinary(string url)
        {
            var authenticationUrl = GetAuthenticatedUrl(url);

            return UrlConsumer.GetBinaryFromURL(authenticationUrl);
        }
        
        private string ConsumeUrlToStringAndPostData(string url, NameValueCollection formValues)
        {
            var authenticationUrl = GetAuthenticatedUrl(url);

            return UrlConsumer.UploadValuesAndGetString(authenticationUrl, formValues);
        }

        protected T ConsumeJsonUrl<T>(string url) where T : class
        {
            var result = ConsumeUrlToString(url);
            if (result == null)
                return null;
            try
            {
                var jsonResult = JsonConvert.DeserializeObject<T>(result);
                return jsonResult;
            }
            catch (Exception error)
            {
                if (LogProvider.HandleAndReturnIfToThrowError(error))
                    throw;
                return null;
            }
        }
        
        protected void Authenticate()
        {
            //TODO - this is no longer correct
            if (HasUser) return;
            var error = new Exception("You need to provide a valid GithubUser with an api token (see http://github.com/blog/170-token-authentication)");
            if (LogProvider.HandleAndReturnIfToThrowError(error))
                throw error;
        }
    }
}
