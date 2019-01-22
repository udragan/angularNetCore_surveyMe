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
					ClientId = "client",

					// no interactive user, use the clientid/secret for authentication
					AllowedGrantTypes = GrantTypes.ClientCredentials,

					// secret for authentication
					ClientSecrets =
					{
						new Secret("secret".Sha256())
					},

					// scopes that client has access to
					AllowedScopes = { "SurveyMe.API" }
				},
				// OpenID Connect hybrid flow client (MVC)
				new Client
				{
					ClientId = "angular",
					ClientName = "Angular Client",
					AllowedGrantTypes = GrantTypes.Hybrid,

					ClientSecrets =
					{
						new Secret("secret".Sha256())
					},

					RedirectUris           = { "http://localhost:50001/signin-oidc" },
					PostLogoutRedirectUris = { "http://localhost:50001/signout-callback-oidc" },

					AllowedScopes =
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						"SurveyMe.API"
					},

					AllowOfflineAccess = true
				},
			};
		}
	}
}
