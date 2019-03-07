using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

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
					RedirectUris = { "http://localhost:4200/home" },

					// where to redirect to after logout
					PostLogoutRedirectUris = { "http://localhost:4200/home" },
					AlwaysIncludeUserClaimsInIdToken = true,
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
	}
}
