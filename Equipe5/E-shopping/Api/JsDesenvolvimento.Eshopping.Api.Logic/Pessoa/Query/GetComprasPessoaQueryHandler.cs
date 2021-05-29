using DapperExtensions;
using JsDesenvolvimento.Data;
using JsDesenvolvimento.Eshopping.Api.Data.Operacao;
using JsDesenvolvimento.Eshopping.Api.Data.Operacao.DBModel;
using JsDesenvolvimento.Eshopping.Api.Data.Operacao.Model;
using JsDesenvolvimento.Eshopping.Api.Logic.Loja.Model;
using JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Model;
using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Query
{
    public class GetComprasPessoaQueryHandler : IRequestHandler<GetComprasPessoaQuery, IList<CompraPessoaLote>>
    {
        private IDbConnectionFactory DbConnectionFactory { get; set; }
        private IDbContextFactory DbContextFactory { get; set; }

        public GetComprasPessoaQueryHandler(IDbConnectionFactory dbConnectionFactory, IDbContextFactory contextFactory)
        {
            this.DbConnectionFactory = dbConnectionFactory;
            this.DbContextFactory = contextFactory;
        }

        public Task<IList<CompraPessoaLote>> Handle(GetComprasPessoaQuery request, CancellationToken cancellationToken)
        {
            using (var ctx = this.DbContextFactory.NewContext())
            {
                var compraItemRepo = ctx.AcquireRepository<ICompraItemRepository>();
                var compras = compraItemRepo.GetComprasPessoa(new Compra()
                {
                    idpessoa = request.Pessoa.idpessoa,
                    idpropietario = request.UserRef.Loja.Propietario,
                    idloja = request.UserRef.Loja.Loja
                }, cancellationToken).Result;

                var loteCompra = compras.GroupBy(a => a.idcompra).Select(a => a.Key);
                IList<CompraPessoaLote> lotePessoa = new List<CompraPessoaLote>();
                foreach (var loteId in loteCompra)
                {
                    lotePessoa.Add(new CompraPessoaLote()
                    {
                        itens = compras.Where(a => a.idcompra == loteId).Select(a => a).ToList(),
                        datacompra = compras.Where(a => a.idcompra == loteId).First().datacompra,
                        sitcompra = compras.Where(a => a.idcompra == loteId).First().sitcompra
                    });
                }

                return Task.FromResult(lotePessoa);
            }
        }
    }
}
