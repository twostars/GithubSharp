using Newtonsoft.Json;

namespace GithubSharp.Core.Base
{
    public abstract class BaseApi
    {
        private readonly IRequestProxy _requestProxy;
        private const string GithubBaseUrl = "https://api.github.com/";

        protected BaseApi(IRequestProxy requestProxy)
        {
            _requestProxy = requestProxy;
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
            var result = _requestProxy.UploadValuesAndGetString(url, request);
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
