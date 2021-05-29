using JsDesenvolvimento.Eshopping.Api.Authentication;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.DBModel;
using JsDesenvolvimento.Eshopping.Api.Logic.Loja.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JsDesenvolvimento.Eshopping.Api.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategorysController : ControllerBase
    {
        private IMediator Mediator { get; set; }
        private IUserRef UserRef { get; set; }

        public CategorysController(IUserRef userRef, IMediator mediator)
        {
            this.UserRef = userRef;
            this.Mediator = mediator;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(CancellationToken cancellationToken)
        {
            try
            {
                var filters = new Categoria();
                var query = new GetCategoriasQuery(filters, this.UserRef);
                var results = this.Mediator.Send(query).Result;
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }
    }
}
