using JsDesenvolvimento.Data.Repository.Impl;
using JsDesenvolvimento.Eshopping.Api.Data.Operacao.Model;
using JsDesenvolvimento.Eshopping.Api.Data.Pessoa.DBModel;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace JsDesenvolvimento.Eshopping.Api.Data.Operacao.Impl
{
    public class DefaultCompraItemRepository : AbstractDefaultRepository<DBModel.CompraItem>, ICompraItemRepository
    {
        public Task<IList<CompraPessoaDto>> GetComprasPessoa(Operacao.DBModel.Compra compra, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew<IList<CompraPessoaDto>>(() =>
            {
                string sql = $@"select cmp.idpessoa {nameof(CompraPessoaDto.idpessoa)}
		                                ,item.idcompra {nameof(CompraPessoaDto.idcompra)}
		                                ,prd.idproduto {nameof(CompraPessoaDto.idproduto)}
		                                ,item.quantidade {nameof(CompraPessoaDto.quantidade)}
		                                ,item.valorunitario {nameof(CompraPessoaDto.valorunitario)}
		                                ,prd.nome {nameof(CompraPessoaDto.nome)}
                                        ,prd.descricao {nameof(CompraPessoaDto.descricao)}
                                        ,cmp.datacompra {nameof(CompraPessoaDto.datacompra)}
                                        , (SELECT img.caminhodiretorio
         	                                FROM produto_imagem img
                                           WHERE img.idproduto = prd.idproduto
                                             AND img.idloja = prd.idloja
                                             AND img.idpropietario = prd.idpropietario
         	                                 AND img.imagemprincipal = 'S'
                                             AND img.situacao = 'A') {nameof(CompraPessoaDto.imagem)}
                                        ,CASE WHEN cmp.situacao = 'P' THEN 'Aguardando Pagamento'
                                        WHEN cmp.situacao = 'C' THEN 'Confirmado'
                                        WHEN cmp.situacao = 'F' THEN 'Saiu para Entrega'
                                        ELSE '' END {nameof(CompraPessoaDto.sitcompra)}
                                  from compra_item item
                                  join compra cmp
                                    on cmp.idcompra = item.idcompra
                                   and cmp.idloja = item.idloja
                                   and cmp.idpropietario = item.idpropietario
                                  join produto prd
                                    on prd.idproduto = item.idproduto
                                   and prd.idloja = item.idloja
                                   and prd.idpropietario = item.idpropietario
                                 where cmp.idpessoa = :prm_idpessoa
                                   and cmp.idpropietario = :prm_idpropietario
                                   and cmp.idloja = :prm_idloja
                                   and cmp.situacao IN ('P','C')";
                
                return this.AttachedContext.InnerConnection.Query<CompraPessoaDto>(sql,
                                                                    param: new
                                                                    {
                                                                        prm_idpessoa = compra.idpessoa,
                                                                        prm_idpropietario = compra.idpropietario,
                                                                        prm_idloja = compra.idloja
                                                                    },
                                                                    transaction: this.AttachedContext.InnerTransaction).ToList();
            });
        }
    }
}
