using Duende.IdentityServer.Models;
using IdentityModel;

namespace IdentityServerAspIdentity;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            // new IdentityResource{
            //     Name = "verification",
            //     UserClaims=new List<string>{
            //         JwtClaimTypes.Email,
            //         JwtClaimTypes.EmailVerified,
            //     }
            // },
            new IdentityResource("color",new []{"favorite_color"})
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("api1"),
            new ApiScope("scope2"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // m2m client credentials flow client
            new Client
            {
                ClientId = "client",
                ClientName = "Client Credentials Client",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { 
                    new Secret("secret".Sha256()) 
                    // new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) 
                    },

                AllowedScopes = { "api1" }
            },

            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "web",
                ClientSecrets = { 
                    new Secret("secret".Sha256()) 
                    // new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) 
                    },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = {
                    "https://localhost:5002/signin-oidc"
                     //"https://localhost:44300/signin-oidc" 
                     },
                FrontChannelLogoutUri = "https://localhost:5002/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { 
                    "openid",
                     "profile",
                      "api1",
                      //"verification" ,
                      "color"}
            },
        };
}
