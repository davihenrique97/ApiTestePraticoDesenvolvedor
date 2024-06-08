using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Enum;
using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Responses;

namespace ApiTestePraticoDesenvolvedor.Tests.SharedKernel.Mock.Application.Commands.Compra.Responses;
public static class CompraIncluirResponseMock
{
    public static CompraIncluirResponse PagamentoJaExistente(DateTime data)
    {
        return new CompraIncluirResponse
        {
            Status = StatusConta.ProblemaAoIncluir,
            Menssagens = ["Problema ao Incluir a Conta.",
                              $"Já Existe Um Pagamento Com a Data {data} !"]
        };
    }
}
