using System;
using GithubSharp.Core.Services;
using Newtonsoft.Json;

namespace GithubSharp.Core.Base
{
    public abstract class BaseApi
    {
        private RequestProxy _requestProxy;

        protected BaseApi(ICacheProvider cache, ILogProvider log)
        {
            CacheProvider = cache;
            LogProvider = log;
            AuthenticationProvider = new NullAuthenticationProvider();
        }

        protected BaseApi(ICacheProvider cache, ILogProvider log, IAuthenticationProvider authenticationProvider)
        {
            CacheProvider = cache;
            LogProvider = log;
            AuthenticationProvider = authenticationProvider;
        }

        protected ICacheProvider CacheProvider { get; set; }
        protected ILogProvider LogProvider { get; set; }
        protected IAuthenticationProvider AuthenticationProvider { get; set; }

        private RequestProxy RequestProxy
        {
            get { return _requestProxy ?? (_requestProxy = new RequestProxy(CacheProvider, LogProvider, AuthenticationProvider)); }
        }

        protected T ConsumeJsonUrlAndPostData<T>(string requestPath) where T : class
        {
            var url = GetFullUrl(requestPath);
            var result = RequestProxy.UploadValuesAndGetString(url);
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

        protected TResponse ConsumeJsonUrlAndPostData<TRequest, TResponse>(string requestPath, TRequest request) where TResponse : class
        {
            var url = GetFullUrl(requestPath);
            var result = RequestProxy.UploadValuesAndGetString(url, request);
            if (result == null)
                return null;
            try
            {
                return JsonConvert.DeserializeObject<TResponse>(result);
            }
            catch (Exception error)
            {
                if (LogProvider.HandleAndReturnIfToThrowError(error))
                    throw;
                return null;
            }
        }

        private string GetFullUrl(string requestPath)
        {
            return string.Format("{0}{1}", RequestProxy.GithubBaseUrl, requestPath);
        }

        protected string ConsumeUrlToString(string requestPath)
        {
            var url = GetFullUrl(requestPath);
            return RequestProxy.GetStringFromUrl(url);
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
    }
}
