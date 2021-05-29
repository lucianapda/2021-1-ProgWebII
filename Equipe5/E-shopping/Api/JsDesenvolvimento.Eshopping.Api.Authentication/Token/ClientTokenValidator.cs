using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Authentication.Token
{
    public class ClientTokenValidator : ISecurityTokenValidator
    {
        public bool CanValidateToken => throw new NotImplementedException();

        public int MaximumTokenSizeInBytes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CanReadToken(string securityToken)
        {
            return true;
        }

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            throw new NotImplementedException();
        }
    }
}
