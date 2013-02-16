using System;
using System.Net;
using System.Text;

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

    public class BasicAuthenticationProvider : IAuthenticationProvider
    {
        private readonly string _userName;
        private readonly string _password;

        public BasicAuthenticationProvider(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        public void AddHeaders(WebHeaderCollection headers)
        {
            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", _userName, _password)));
            headers.Add("Authorization", string.Format("Basic {0}", token));
        }

        public string Username
        {
            get { return _userName; }
        }
    }


    [Obsolete]
    public interface IAuthProvider
    {
        IAuthResponse Login();
        IAuthResponse Logout();
        IAuthPreRequestResponse PreRequestAuth(
            IGithubRequest githubRequest,
            System.Net.HttpWebRequest webRequest);
        string PrepareUri(string uri);
        string GetToken();
        void RestoreFromToken(string token);
        bool IsAuthenticated { get; set; }
        string Username { get; set; }
    }
    [Obsolete]
    public interface IAuthResponse
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
    [Obsolete]
    public class AuthResponse : IAuthResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    [Obsolete]
    public interface IAuthPreRequestResponse : IAuthResponse
    {
        System.Net.HttpWebRequest WebRequest
        {
            get;
            set;
        }
    }
    [Obsolete]
    public class AuthPreRequestResponse : AuthResponse, IAuthPreRequestResponse
    {
        public System.Net.HttpWebRequest WebRequest
        {
            get;
            set;
        }
    }
}

