using System.Net;
using GithubSharp.Core.Services;
using Newtonsoft.Json;

namespace GithubSharp.Core.Base
{
    public class RequestProxy : IRequestProxy
    {
        private readonly ILogProvider _logProvider;
        private readonly IAuthenticationProvider _authenticationProvider;
        private const string _userAgent = "GithubSharp";

        public RequestProxy(ILogProvider logProvider, IAuthenticationProvider authenticationProvider)
        {
            _authenticationProvider = authenticationProvider;
            _logProvider = logProvider;
        }

        private WebClient InitRequest()
        {
            var webClient = new WebClient();
            webClient.Headers.Add("user-agent", _userAgent);
            _authenticationProvider.AddHeaders(webClient.Headers);
            return webClient;
        }

        public string UploadValuesAndGetString<TRequest>(string url, TRequest request, string method = "POST")
        {
            try
            {
                var webClient = InitRequest();
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                var mystr = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                _logProvider.LogMessage("webClient.UploadString url = {0}| method = {1}| data = {2} ", url, method, mystr);
                return webClient.UploadString(url, method, mystr);
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
                var webClient = InitRequest();
                _logProvider.LogMessage("webClient.DownloadString url = {0}", url);
                return webClient.DownloadString(url);
            }
            catch (WebException error)
            {
                _logProvider.LogError(error);
                throw;
            }
        }
    }
}