using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Responses;

namespace ApiTestePraticoDesenvolvedor.Tests.SharedKernel.Mock.Application.Commands.Compra.Responses;
public static class CompraIncluirRequestMock
{
    public static CompraIncluirRequest GetMocked()
    {
        return new CompraIncluirRequest
        {
            Nome = "Conta de Luz",
            ValorOriginal = 200,
            DataVencimento = DateTime.Now,
            DataPagamento = DateTime.Now
        };
    }
}
