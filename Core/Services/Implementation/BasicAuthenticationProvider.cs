using System;
using System.Net;
using System.Text;

namespace GithubSharp.Core.Services.Implementation
{
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
    public class OAuthAuthenticationProvider : IAuthenticationProvider
    {
        private readonly string _token;

        public OAuthAuthenticationProvider(string token)
        {
            _token = token;
            Username = "Unknown - using token auth. Please set via a /users get operation";
        }

        public void AddHeaders(WebHeaderCollection headers)
        {
            headers.Add("Authorization", string.Format("token {0}", _token));
        }

        public string Username { get; set; }
    }
}