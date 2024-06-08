using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Requests;
using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Responses;

namespace ApiTestePraticoDesenvolvedor.Application.Interfaces.Conta;
public interface IContaService
{
    ContaIncluirResponse Incluir(ContaIncluirRequest request);
    IEnumerable<ContaListagemResponse> Listar(string? idConta);
}
