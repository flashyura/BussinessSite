using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BussinessSite.OAuth2.Startup))]

namespace BussinessSite.OAuth2
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            var inMemoryManager = new InMemoryManager();
            var factory = new IdentityServerServiceFactory()
                .UseInMemoryUsers(inMemoryManager.GetUsers())
                .UseInMemoryScopes(inMemoryManager.GetScopes())
                .UseInMemoryClients(inMemoryManager.GetClients());
            var certifcate = Convert.FromBase64String(ConfigurationManager.AppSettings["CertifcateSrting"]);
            var options = new IdentityServerOptions
            {
                SigningCertificate = new X509Certificate2(certifcate, ConfigurationManager.AppSettings["SigningCertificatePassword"]),
                RequireSsl = false,
                Factory = factory
            };
            app.UseIdentityServer(options);
        }
    }
}
