using JsDesenvolvimento.Data.Repository;
using JsDesenvolvimento.Eshopping.Api.Data.Operacao.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JsDesenvolvimento.Eshopping.Api.Data.Operacao
{
    public interface ICompraItemRepository: IDefaultRepository<DBModel.CompraItem>
    {
        Task<IList<CompraPessoaDto>> GetComprasPessoa(Operacao.DBModel.Compra compra, CancellationToken cancellationToken);
    }
}
