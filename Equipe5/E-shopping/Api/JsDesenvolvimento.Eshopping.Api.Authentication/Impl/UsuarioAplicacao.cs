using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JsDesenvolvimento.Eshopping.Api.Authentication.Model;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace JsDesenvolvimento.Eshopping.Api.Authentication.Impl
{
    public class UsuarioAplicacao : IUserRef
    {
        public LojaAutenticada Loja
        {
            get
            {
                string propietario = GetClaimsIdentity().FirstOrDefault(a => a.Type == "propietario")?.Value;
                string loja = GetClaimsIdentity().FirstOrDefault(a => a.Type == "loja")?.Value;
                string login = _accessor.HttpContext.User.Identity.Name;

                return new LojaAutenticada(Convert.ToInt32(propietario), Convert.ToInt32(loja), login);
            }
        }

        public string Nome => _accessor.HttpContext.User.Identity.Name;

        private readonly IHttpContextAccessor _accessor;

        public UsuarioAplicacao(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }
}