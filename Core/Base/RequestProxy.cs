using System;
using System.Net;
using GithubSharp.Core.Services;
using Newtonsoft.Json;

namespace GithubSharp.Core.Base
{
    internal class RequestProxy
    {
        internal RequestProxy(ICacheProvider cache, ILogProvider logProvider, IAuthenticationProvider authenticationProvider)
        {
            AuthenticationProvider = authenticationProvider;
            CacheProvider = cache;
            LogProvider = logProvider;
        }

        internal ICacheProvider CacheProvider;
        internal ILogProvider LogProvider;
        internal IAuthenticationProvider AuthenticationProvider;

        internal string GithubBaseUrl { get { return "https://api.github.com/"; } }

        internal string UploadValuesAndGetString<TRequest>(string url, TRequest request)
        {
            try
            {
                var webClient = new WebClient();
                AuthenticationProvider.AddHeaders(webClient.Headers);
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                var mystr = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                var result = webClient.UploadString(url, "POST", mystr);
                return result;
            }
            catch (Exception ex)
            {
                if (LogProvider.HandleAndReturnIfToThrowError(ex))
                    throw;
                return null;
            }
        }
        internal string UploadValuesAndGetString(string url)
        {
            try
            {
                var webClient = new WebClient();
                AuthenticationProvider.AddHeaders(webClient.Headers);
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                var result = webClient.UploadString(url, "POST", "");
                return result;
            }
            catch (Exception ex)
            {
                if (LogProvider.HandleAndReturnIfToThrowError(ex))
                    throw;
                return null;
            }
        }

        internal string GetStringFromUrl(string url)
        {
            var cacheKey = string.Format("GetStringFromURL_{0}", url);
            var cached = CacheProvider.Get<string>(cacheKey);
            if (cached != null)
            {
                LogProvider.LogMessage("Url.GetStringFromURL  :  Returning cached result");
                return cached;
            }

            LogProvider.LogMessage("Url.GetStringFromURL  :  Cached result unavailable, fetching url content");

            string result;
            try
            {
                var webClient = new WebClient();
                AuthenticationProvider.AddHeaders(webClient.Headers);
                result = webClient.DownloadString(url);
            }
            catch (Exception error)
            {
                if (LogProvider.HandleAndReturnIfToThrowError(error))
                    throw;
                return null;
            }

            CacheProvider.Set(result, cacheKey);
            return result;
        }
    }
}