using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;

using BussinesSite.WebApi.Models;
using BussinesSite.WebApi.Providers;
using Microsoft.Owin.Security.Jwt;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;

namespace BussinesSite.WebApi
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            //app.CreatePerOwinContext(ApplicationDbContext.Create);
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            //// Enable the application to use a cookie to store information for the signed in user
            //// and to use a cookie to temporarily store information about a user logging in with a third party login provider
            //app.UseCookieAuthentication(new CookieAuthenticationOptions());
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            //// Configure the application for OAuth based flow
            //PublicClientId = "self";
            //OAuthOptions = new OAuthAuthorizationServerOptions
            //{
            //    TokenEndpointPath = new PathString("/Token"),
            //    Provider = new ApplicationOAuthProvider(PublicClientId),
            //    AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
            //    // In production mode set AllowInsecureHttp = false
            //    AllowInsecureHttp = true
            //};

            // Enable the application to use bearer tokens to authenticate users
            //app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
            var certificate = new X509Certificate2(Convert.FromBase64String("MIIC1DCCAbygAwIBAgIQGU8bZgi257BN+dMzrNaQSDANBgkqhkiG9w0BAQUFADATMREwDwYDVQQDEwhGaWxpcC1QQzAeFw0xNjAyMjEwNjQ4MzdaFw0xNzAyMjEwMDAwMDBaMBMxETAPBgNVBAMTCEZpbGlwLVBDMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA2/Ze/ru74n5YRTQKQujQOx4P7poPDuVfSi7aiBa7BV4pbBGXtzU8Mwt7LhewJnvbtJVdOj3S/4ndD3Zl65zV4RtqPAtGI0MJnMLxPibKaqnvikhLj/K5EEJ4yqXXlRSbH1VwwHzFtHmxnZd2KlmpNKF4WHaOzInoYmi36sffoAaikP7vmvUcO88X4tMP/KWxp5JZo5cQmLcKO3XiRDq532gezItq/p/iucHukF3WRMOL/73wB9bUcBU2/GIkFyB7Ne0YmJfhUopyCZnRh0UQP3DKrO1iKCy1Lje+TMi8hOoCfok8u1ZaJuueXgSf/J2S+AEe3M8D4OoYo6W0p+ZebwIDAQABoyQwIjALBgNVHQ8EBAMCBDAwEwYDVR0lBAwwCgYIKwYBBQUHAwEwDQYJKoZIhvcNAQEFBQADggEBANT5ltvrZJMHZNVO8juAO+PxyCSYmvIKNO2vBIglewmoF4vfdyABnAoIzHgKn5uvq1oPJCeiUHoNpzBMQiWqGW+NNL6wfTsZyfM24+EMv0ZDvkdm/B356tTZbPi/Pg/4vqDqAxbS6eE+VpBlZPHfDqCzlYKL+Ahhaq+xS4G0FJCvjWFt/EncwnVijuur3VYV+KxteAE+2ClI3N60nBH4UiOyigZ3Mwk0ONYu2R8X/AVMNpjKYXyXEGSi/JrCCNvINmnP4+SWpfFjVD8DDFK9VVsM6tl0HPM8qy3VkipCCnLZ6MRRIhrDnj8FnOZxCq7aI5fP7WDiwHKC/2zsX6LcOGs="));
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AllowedAudiences = new[] { "http://localhost:51886/resources" },
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = "http://localhost:51886/resources",
                    ValidIssuer = "http://localhost:51886",
                    IssuerSigningKey = new X509SecurityKey(certificate)//public key
                },
            });

        }
    }
}
