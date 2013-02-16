using System;
using System.Net;
using GithubSharp.Core.Services;
using Newtonsoft.Json;

namespace GithubSharp.Core.Base
{
    internal class RequestProxy
    {
        private readonly ICacheProvider _cacheProvider;
        private readonly ILogProvider _logProvider;
        private readonly IAuthenticationProvider _authenticationProvider;
        
        internal RequestProxy(ICacheProvider cache, ILogProvider logProvider, IAuthenticationProvider authenticationProvider)
        {
            _authenticationProvider = authenticationProvider;
            _cacheProvider = cache;
            _logProvider = logProvider;
        }


        internal string UploadValuesAndGetString<TRequest>(string url, TRequest request)
        {
            try
            {
                var webClient = new WebClient();
                _authenticationProvider.AddHeaders(webClient.Headers);
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                var mystr = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                var result = webClient.UploadString(url, "POST", mystr);
                return result;
            }
            catch (Exception ex)
            {
                if (_logProvider.HandleAndReturnIfToThrowError(ex))
                    throw;
                return null;
            }
        }
        internal string UploadValuesAndGetString(string url)
        {
            try
            {
                var webClient = new WebClient();
                _authenticationProvider.AddHeaders(webClient.Headers);
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                var result = webClient.UploadString(url, "POST", "");
                return result;
            }
            catch (Exception ex)
            {
                if (_logProvider.HandleAndReturnIfToThrowError(ex))
                    throw;
                return null;
            }
        }

        internal string GetStringFromUrl(string url)
        {
            var cacheKey = string.Format("GetStringFromURL_{0}", url);
            var cached = _cacheProvider.Get<string>(cacheKey);
            if (cached != null)
            {
                _logProvider.LogMessage("Url.GetStringFromURL  :  Returning cached result");
                return cached;
            }

            _logProvider.LogMessage("Url.GetStringFromURL  :  Cached result unavailable, fetching url content");

            string result;
            try
            {
                var webClient = new WebClient();
                _authenticationProvider.AddHeaders(webClient.Headers);
                result = webClient.DownloadString(url);
            }
            catch (Exception error)
            {
                if (_logProvider.HandleAndReturnIfToThrowError(error))
                    throw;
                return null;
            }

            _cacheProvider.Set(result, cacheKey);
            return result;
        }
    }
}