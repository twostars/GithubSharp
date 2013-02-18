﻿using System.Configuration;
using GithubSharp.Core.Services;
using GithubSharp.Core.Services.Implementation;

namespace GithubSharp.Tests.CoreTests
{
    public static class AuthenticationProvider
    {
        public static IAuthenticationProvider Basic()
        {
            var username = ConfigurationManager.AppSettings["username"];
            var password = ConfigurationManager.AppSettings["password"];
            return new BasicAuthenticationProvider(username, password);
        }
        public static IAuthenticationProvider OAuth()
        {
            var token = ConfigurationManager.AppSettings["authtoken"];
            return new OAuthAuthenticationProvider(token);
        }

    }
}