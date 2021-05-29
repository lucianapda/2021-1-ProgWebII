using JsDesenvolvimento.Data;
using JsDesenvolvimento.Eshopping.Api.Data.Operacao;
using JsDesenvolvimento.Eshopping.Api.Logic.Loja.Model;
using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Loja.Cqrs
{
    public class FinalizarCompraCommandHandler : IRequestHandler<FinalizarCompraCommand, FinalizarCompraResponse>
    {
        private IDbConnectionFactory DbConnectionFactory { get; set; }
        private IDbContextFactory DbContextFactory { get; set; }

        public FinalizarCompraCommandHandler(IDbConnectionFactory dbConnectionFactory, IDbContextFactory contextFactory)
        {
            this.DbConnectionFactory = dbConnectionFactory;
            this.DbContextFactory = contextFactory;
        }

        public Task<FinalizarCompraResponse> Handle(FinalizarCompraCommand request, CancellationToken cancellationToken)
        {
            using (var ctx = this.DbContextFactory.NewTransactionContext())
            {
                try
                {
                    var repo = ctx.AcquireRepository<ICompraRepository>();
                    var itemRepo = ctx.AcquireRepository<ICompraItemRepository>();

                    var compra = repo.InsertAsync(new Data.Operacao.DBModel.Compra()
                    {
                        idpropietario = request.UserRef.Loja.Propietario,
                        idloja = request.UserRef.Loja.Loja,
                        datacompra = DateTimeOffset.UtcNow,
                        idpessoa = request.FinalizarCompraRequest.Comprador.idpessoa,
                        situacao = "P",
                        idendereco = request.FinalizarCompraRequest.Endereco.id
                    }, cancellationToken).Result;

                    foreach (var item in request.FinalizarCompraRequest.ProdutosCompra)
                    {
                        var itens = itemRepo.InsertAsync(new Data.Operacao.DBModel.CompraItem()
                        {
                            idcompra = compra.idcompra,
                            idloja = request.UserRef.Loja.Loja,
                            idpropietario = request.UserRef.Loja.Propietario,
                            idproduto = item.idproduto,
                            quantidade = item.quantidade,
                            valorunitario = item.precounitario
                        }, cancellationToken);
                    }

                    ctx.Commit();

                    return Task.FromResult<FinalizarCompraResponse>(FinalizarCompraResponse.Ok(compra));
                }
                catch(Exception ex)
                {
                    return Task.FromResult<FinalizarCompraResponse>(FinalizarCompraResponse.Falha(ex.Message));
                }
            }
        }
    }
}
