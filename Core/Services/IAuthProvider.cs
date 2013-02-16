using System.Net;

namespace GithubSharp.Core.Services
{
    public interface IAuthenticationProvider
    {
        void AddHeaders(WebHeaderCollection headers);
        string Username { get; }
    }

    class NullAuthenticationProvider : IAuthenticationProvider
    {
        public void AddHeaders(WebHeaderCollection headers)
        {
            return;
        }

        public string Username
        {
            get { return string.Empty; }
        }
    }
}

