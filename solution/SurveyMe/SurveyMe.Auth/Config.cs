using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace udragan.netCore.SurveyMe.Auth
{
	public static class Config
	{
		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile(),
				new IdentityResources.Email()
			};
		}

		public static IEnumerable<ApiResource> GetApis()
		{
			return new List<ApiResource>
			{
				new ApiResource("SurveyMe.API", "Survey Me API")
			};
		}

		public static IEnumerable<Client> GetClients()
		{
			return new List<Client>
			{
				new Client
				{
					ClientId = "SPA",
					ClientName = "angular SPA client",
					AllowedGrantTypes = GrantTypes.Implicit,
					AllowAccessTokensViaBrowser = true,
					AccessTokenLifetime = 60, // TODO: 1 minute for testing!

					//// secret for authentication
					//ClientSecrets =
					//{
					//	new Secret("angular".Sha256())
					//},
				
					// where to redirect to after login
					RedirectUris = { "http://localhost:50001/signin-oidc" },

					// where to redirect to after logout
					PostLogoutRedirectUris = { "http://localhost:50001/signout-callback-oidc" },

					AllowedScopes = new List<string>
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						"SurveyMe.API",
					},

					//AllowOfflineAccess = true
				}
			};
		}

		public static List<TestUser> GetUsers()
		{
			return new List<TestUser>
			{
				new TestUser
				{
					SubjectId = "1",
					Username = "alice",
					Password = "password",

					Claims = new []
					{
						new Claim("name", "Alice"),
						new Claim("website", "https://alice.com")
					}
				},
				new TestUser
				{
					SubjectId = "2",
					Username = "bob",
					Password = "password",

					Claims = new []
					{
						new Claim("name", "Bob"),
						new Claim("website", "https://bob.com")
					}
				}
			};
		}
	}
}
