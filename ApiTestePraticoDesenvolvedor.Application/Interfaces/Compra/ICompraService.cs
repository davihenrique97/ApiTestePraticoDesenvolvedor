using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Responses;

namespace ApiTestePraticoDesenvolvedor.Application.Interfaces.Compra;
public interface ICompraService
{
    CompraIncluirResponse Incluir(CompraIncluirRequest request);
    IEnumerable<CompraListagemResponse> Listar(string? idConta);
}
