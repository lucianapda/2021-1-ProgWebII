using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsDesenvolvimento.Data;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using JsDesenvolvimento.Eshopping.Api.Data.Cliente;
using System.Threading;
using JsDesenvolvimento.Eshopping.Api.Data.Loja;

namespace JsDesenvolvimento.Eshopping.Api.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        private IDbConnectionFactory DbConnectionFactory { get; set; }
        private IDbContextFactory DbContextFactory { get; set; }

        public ValuesController(IDbConnectionFactory dbConnectionFactory, IDbContextFactory contextFactory)
        {
            this.DbConnectionFactory = dbConnectionFactory;
            this.DbContextFactory = contextFactory;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Data.Cliente.DBModel.Loja> Get(int id, CancellationToken cancellationToken)
        {
            using(var ctx = this.DbContextFactory.NewContext())
            {
                var repo = ctx.AcquireRepository<IProdutoRepository>();
                var novaLoja = repo.InsertAsync(new Data.Loja.DBModel.Produto()
                {
                    idproduto = 1,
                    idloja = 1,
                    idpropietario = 1,
                    nome = "Calça Jeans",
                    descricao = "Calça super da moda",
                    situacao = "A",
                    precounitario = 45,
                    datacadastro = DateTime.Now                    
                }, cancellationToken).Result;

                return Ok(novaLoja);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
