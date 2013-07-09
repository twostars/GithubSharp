using Newtonsoft.Json;

namespace GithubSharp.Core.Base
{
    public abstract class BaseApi
    {
        private readonly IRequestProxy _requestProxy;
        private const string GithubBaseUrl = "https://api.github.com/";
        private const int DefaultPerPageLimit = 30; // Github limits us to 30 entries per page by default

        protected BaseApi(IRequestProxy requestProxy)
        {
            _requestProxy = requestProxy;
            PerPageLimit = DefaultPerPageLimit;
        }

        public int PerPageLimit
        {
            get;
            set;
        }

        protected void AppendPerPageLimit(ref string requestUrl)
        {
            if (PerPageLimit == DefaultPerPageLimit)
                return;

            var separator = "?";
            if (requestUrl.Contains(separator))
                separator = "&";

            requestUrl = string.Format("{0}{1}per_page={2}", requestUrl, separator, PerPageLimit);
        }

        protected T ConsumeJsonUrlAndPostData<T>(string requestPath) where T : class
        {
            var url = GetFullUrl(requestPath);
            var result = _requestProxy.UploadValuesAndGetString(url);
            return result == null ? null : JsonConvert.DeserializeObject<T>(result);
        }

        protected TResponse ConsumeJsonUrlAndPostData<TRequest, TResponse>(string requestPath, TRequest request) where TResponse : class
        {
            var url = GetFullUrl(requestPath);
            var result = _requestProxy.UploadValuesAndGetString(url, request, "POST");
            return result == null ? null : JsonConvert.DeserializeObject<TResponse>(result);
        }

        protected TResponse ConsumeJsonUrlAndPatchData<TRequest, TResponse>(string requestPath, TRequest request) where TResponse : class
        {
            var url = GetFullUrl(requestPath);
            var result = _requestProxy.UploadValuesAndGetString(url, request, "PATCH");
            return result == null ? null : JsonConvert.DeserializeObject<TResponse>(result);
        }

        protected TResponse ConsumeJsonUrlAndDeleteData<TRequest, TResponse>(string requestPath, TRequest request) where TResponse : class
        {
            var url = GetFullUrl(requestPath);
            var result = _requestProxy.UploadValuesAndGetString(url, request, "DELETE");
            return result == null ? null : JsonConvert.DeserializeObject<TResponse>(result);
        }

        protected string ConsumeUrlToString(string requestPath)
        {
            var url = GetFullUrl(requestPath);
            return _requestProxy.GetStringFromUrl(url);
        }

        protected T ConsumeJsonUrl<T>(string url) where T : class
        {
            var result = ConsumeUrlToString(url);
            return result == null ? null : JsonConvert.DeserializeObject<T>(result);
        }

        private static string GetFullUrl(string requestPath)
        {
            return string.Format("{0}{1}", GithubBaseUrl, requestPath);
        }
    }
}
