using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Enum;
using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Responses;

namespace ApiTestePraticoDesenvolvedor.Tests.SharedKernel.Mock.Application.Commands.Conta.Responses;
public static class ContaIncluirResponseMock
{
    public static ContaIncluirResponse ContaIncluirResponsePagamentoJaExistente(DateTime data)
    {
        return new ContaIncluirResponse
        {
            Status = StatusConta.ProblemaAoIncluir,
            Mensagens = ["Problema ao Incluir a Conta.",
                              $"Já Existe Um Pagamento Com a Data {data} !"]
        };
    }

    public static ContaIncluirResponse ContaIncluirResponseFalha()
    {
        return new ContaIncluirResponse
        {
            Status = StatusConta.ProblemaAoIncluir,
            Mensagens = ["Problema ao Incluir a Conta.",
                              "Conta não Inclusa!"]
        };
    }
}
