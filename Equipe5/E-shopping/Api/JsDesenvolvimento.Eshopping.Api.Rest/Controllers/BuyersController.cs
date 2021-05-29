using JsDesenvolvimento.Eshopping.Api.Authentication;
using JsDesenvolvimento.Eshopping.Api.Data.Pessoa.DBModel;
using JsDesenvolvimento.Eshopping.Api.Logic.Loja.Model;
using JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Cqrs;
using JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Query;
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
    public class BuyersController : ControllerBase
    {
        private IMediator Mediator { get; set; }
        private IUserRef UserRef { get; set; }

        public BuyersController(IUserRef userRef, IMediator mediator)
        {
            this.UserRef = userRef;
            this.Mediator = mediator;
        }

        [HttpGet("{idpessoa}/address")]
        public ActionResult<IList<PessoaEndereco>> GetEnderecos([FromRoute]int idpessoa, CancellationToken cancellationToken)
        {
            try
            {
                //Carrinho carrinho = null;
                //using (var reader = new StreamReader(this.Request.Body))
                //{
                //    string json = reader.ReadToEnd();
                //    carrinho = JsonConvert.DeserializeObject<Carrinho>(json);
                //}

                var query = new GetEnderecosCompradorQuery(new Pessoa()
                {
                    idpessoa = idpessoa
                }, this.UserRef);
                var results = this.Mediator.Send(query).Result;
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpPost("cadastrarPessoa")]
        public ActionResult<Pessoa> CadastrarPessoa([FromBody] Pessoa buyer, CancellationToken cancellationToken)
        {
            try
            {
                var query = new CadastrarCompradorCommand(buyer, this.UserRef);
                var results = this.Mediator.Send(query).Result;
                return Ok(results.Comprador);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost("cadastrarEndereco")]
        public ActionResult<PessoaEndereco> cadastrarEndereco([FromBody] PessoaEndereco buyerAddress, CancellationToken cancellationToken)
        {
            try
            {
                var query = new CadastrarEnderecoCompradorCommand(buyerAddress, this.UserRef);
                var results = this.Mediator.Send(query).Result;
                return Ok(results.Endereco);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpPost("fazerLogin")]
        public ActionResult<PessoaEndereco> fazerLogin([FromBody] Pessoa buyer, CancellationToken cancellationToken)
        {
            try
            {
                var query = new FazerLoginCommand(new Logic.Pessoa.Model.FazerLoginCommandRequest()
                {
                    Pessoa = buyer
                }, this.UserRef);
                var results = this.Mediator.Send(query).Result;
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpPost("buscarCompras")]
        public ActionResult<IList<CompraPessoaLote>> buscarCompras([FromBody] Pessoa buyer, CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetComprasPessoaQuery(buyer, this.UserRef);
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
