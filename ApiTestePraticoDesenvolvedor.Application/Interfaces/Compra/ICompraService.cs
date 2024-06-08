using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Responses;

namespace ApiTestePraticoDesenvolvedor.Application.Interfaces.Compra;
public interface ICompraService
{
    ContaIncluirResponse Incluir(CompraIncluirRequest request);
    IEnumerable<ContaListagemResponse> Listar(string? idConta);
}
