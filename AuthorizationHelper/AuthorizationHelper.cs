using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationHelper
{
    public class AuthorizationHelper
    {
        const string aadTenant = "https://login.windows.net/6e8992ec-76d5-4ea5-8eae-b0c5e558749a";
        public const string aadResource = "https://g-r10-dev06d3da61ac20a99f87devaos.cloudax.dynamics.com";
        const string aadClientAppId = "e41c7a87-0d88-4b49-bb54-a80e7027fa65";
        const string aadClientAppSecret = "[UM@+/6MuQ3Wpj23uM+U[c+?*DMpcF49";
        /// <summary>
        /// Retrieves an authentication header from the service.
        /// </summary>
        /// <returns>The authentication header for the Web API call.</returns>
        public static string GetAuthenticationHeader()
        {
            AuthenticationContext authenticationContext = new AuthenticationContext(aadTenant);
            AuthenticationResult authenticationResult;
            
            var creadential = new ClientCredential(aadClientAppId, aadClientAppSecret);
            authenticationResult = authenticationContext.AcquireTokenAsync(aadResource, creadential).Result;
            
            // Create and get JWT token
            return authenticationResult.CreateAuthorizationHeader();
        }
    }
}

