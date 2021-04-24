using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityyKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityyKey));
        }
    }
}
