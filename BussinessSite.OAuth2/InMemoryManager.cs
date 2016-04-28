using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;

namespace BussinessSite.OAuth2
{
    public class InMemoryManager
    {
        public List<InMemoryUser> GetUsers()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Subject = "a@a",
                    Username = "admin",
                    Password = "admin",
                    Claims = new []
                    {
                        new Claim(Constants.ClaimTypes.Name, "Iurii Shevchuk")
                    }
                }
            };
        }
        public IEnumerable<Scope> GetScopes()
        {
            return new[]
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.OfflineAccess,
                new Scope
                {
                    Name = "mRead",
                    DisplayName = "mRead user data"
                }
            };
        }
        public IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "testClien",
                    ClientSecrets =  new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    ClientName="flashyura",
                    Flow = Flows.ResourceOwner,
                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        "read"
                    },
                    Enabled = true
                }
            };
        }
    }
}