using System;
using System.Net;
using GithubSharp.Core.Services;

namespace DevBadges.Infrastructure.BadgeProviders
{
	/// <summary>
	/// Anonymous authentication provider to use in cases when there is no need to authenticate,
	/// like when we want to access only public GitHub information.
	/// </summary>
	public class AnonymousAuthenticationProvider : IAuthenticationProvider
	{
		#region IAuthenticationProvider implementation
		/// <summary>
		/// Adds the headers.
		/// </summary>
		/// <param name="headers">The headers.</param>
		public void AddHeaders (WebHeaderCollection headers)
		{
		}

		/// <summary>
		/// Gets the username.
		/// </summary>
		/// <value>The username.</value>
		public string Username {
			get {
				return "anonymous";
			}
		}
		#endregion
	}
}