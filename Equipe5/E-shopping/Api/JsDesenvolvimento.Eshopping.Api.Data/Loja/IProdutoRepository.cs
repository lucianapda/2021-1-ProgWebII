using DapperExtensions;
using JsDesenvolvimento.Data.Repository;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JsDesenvolvimento.Eshopping.Api.Data.Loja
{
    public interface IProdutoRepository : IDefaultRepository<DBModel.Produto>
    {
        Task<IList<ProdutoDto>> FetchDto(IPredicate predicate, CancellationToken cancellationToken);
    }
}
