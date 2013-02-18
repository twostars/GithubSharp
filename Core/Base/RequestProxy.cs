using System.Net;
using GithubSharp.Core.Services;
using Newtonsoft.Json;

namespace GithubSharp.Core.Base
{
    public class RequestProxy : IRequestProxy
    {
        private readonly ILogProvider _logProvider;
        private readonly IAuthenticationProvider _authenticationProvider;

        public RequestProxy(ILogProvider logProvider, IAuthenticationProvider authenticationProvider)
        {
            _authenticationProvider = authenticationProvider;
            _logProvider = logProvider;
        }

        public string UploadValuesAndGetString<TRequest>(string url, TRequest request, string method = "POST")
        {
            try
            {
                var webClient = new WebClient();
                _authenticationProvider.AddHeaders(webClient.Headers);
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                var mystr = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                _logProvider.LogMessage("webClient.UploadString url = {0}| method = {1}| data = {2} ", url, method, mystr);
                var result = webClient.UploadString(url, method, mystr);
                return result;
            }
            catch (WebException ex)
            {
                _logProvider.LogError(ex);
                throw;
            }
        }

        public string UploadValuesAndGetString(string url)
        {
            return UploadValuesAndGetString(url, "");
        }

        public string GetStringFromUrl(string url)
        {
            try
            {
                var webClient = new WebClient();
                _authenticationProvider.AddHeaders(webClient.Headers);
                _logProvider.LogMessage("webClient.DownloadString url = {0}", url);
                var result = webClient.DownloadString(url);
                return result;
            }
            catch (WebException error)
            {
                _logProvider.LogError(error);
                throw;
            }
        }
    }
}