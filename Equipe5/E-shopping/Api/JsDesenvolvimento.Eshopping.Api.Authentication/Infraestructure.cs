using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using JsDesenvolvimento.Eshopping.Api.Authentication.Token;

namespace JsDesenvolvimento.Eshopping.Api.Authentication
{
    public static class Infraestructure
    {
        public static void AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var key = configuration["SecretKey"];

            //RSACryptoServiceProvider rsaCrypto = ImportPrivateKey(key);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
                x.SecurityTokenValidators.Add(new ClientTokenValidator());
            });
        }

        public static void AddAuthorizationConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy => policy.RequireClaim("Store", "admin"));
                options.AddPolicy("Usuario", policy => policy.RequireClaim("Store", "user"));
                options.AddPolicy("Cliente", policy => policy.RequireClaim("Store", "client"));
            });
        }

        //public static RSACryptoServiceProvider ImportPrivateKey(string pem)
        //{
        //    PemReader pr = new PemReader(new StringReader(pem));
        //    AsymmetricCipherKeyPair KeyPair = (AsymmetricCipherKeyPair)pr.ReadObject();
        //    RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)KeyPair.Private);

        //    RSACryptoServiceProvider csp = new RSACryptoServiceProvider();// cspParams);
        //    csp.ImportParameters(rsaParams);
        //    return csp;
        //}
    }
}
