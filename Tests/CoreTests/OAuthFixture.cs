using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using GithubSharp.Core.API;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class OAuthFixture
    {
        [Test]
        public void CanCreateOAuthToken()
        {

            var clientId = ConfigurationManager.AppSettings["clientid"];
            var clientsecret = ConfigurationManager.AppSettings["client"];
            var authrepo = new AuthorizationsRepository()
        }
    }
}
