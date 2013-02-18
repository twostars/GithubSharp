namespace GithubSharp.Core.Base
{
    public interface IRequestProxy
    {
        string UploadValuesAndGetString<TRequest>(string url, TRequest request, string method = "POST");
        string UploadValuesAndGetString(string url);
        string GetStringFromUrl(string url);
    }
}