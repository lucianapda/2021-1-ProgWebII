using JsDesenvolvimento.Data;
using JsDesenvolvimento.Eshopping.Api.Authentication;
using JsDesenvolvimento.Eshopping.Api.Data.Loja;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.DBModel;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.Model;
using JsDesenvolvimento.Eshopping.Api.Data.Pessoa.DBModel;
using JsDesenvolvimento.Eshopping.Api.Logic.Loja.Cqrs;
using JsDesenvolvimento.Eshopping.Api.Logic.Loja.Model;
using JsDesenvolvimento.Eshopping.Api.Logic.Loja.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JsDesenvolvimento.Eshopping.Api.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private IMediator Mediator { get; set; }
        private IUserRef UserRef { get; set; }

        public ProductsController(IUserRef userRef, IMediator mediator)
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
                var produtoRequest = new ProdutoDto();

                var query = new GetProdutosQuery(produtoRequest, this.UserRef);
                var results = this.Mediator.Send(query).Result;
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetById([FromRoute]int id, CancellationToken cancellationToken)
        {
            try
            {
                var produtoRequest = new ProdutoDto()
                {
                    idproduto = id
                };

                var query = new GetProdutoByIdQuery(produtoRequest, this.UserRef);
                var results = this.Mediator.Send(query).Result;
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpGet("{id}/imagens")]
        public ActionResult<Produto> GetImagens([FromRoute]int id, CancellationToken cancellationToken)
        {
            try
            {
                var imagemRequest = new ImagemProduto()
                {
                    idproduto = id
                };

                var query = new GetProdutoImagensQuery(imagemRequest, this.UserRef);
                var results = this.Mediator.Send(query).Result;
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpPost("finalizarCompra")]
        public ActionResult<FinalizarCompraResponse> FinalizarCompra([FromBody] Carrinho carrinho, CancellationToken cancellationToken)
        {
            try
            {
                var produtoRequest = new FinalizarCompraRequest()
                {
                    ProdutosCompra = carrinho.produtos,
                    Comprador = carrinho.comprador,
                    Endereco = carrinho.endereco
                };

                var query = new FinalizarCompraCommand(produtoRequest, this.UserRef);
                var results = this.Mediator.Send(query).Result;
                return Ok(results.CompraPendente);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        public class Carrinho
        {
            public PessoaEndereco endereco { get; set; }
            public IList<ProdutoCompradoDto> produtos { get; set; }
            public Pessoa comprador { get; set; }
        }
    }
}
