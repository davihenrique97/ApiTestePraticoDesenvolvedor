using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Responses;

namespace ApiTestePraticoDesenvolvedor.Tests.SharedKernel.Mock.Application.Commands.Compra.Responses;
public static class CompraListagemResponseMock
{
    public static IEnumerable<ContaListagemResponse> ContaListagem()
    {
        return
        [
            new ContaListagemResponse
            {
                Id = Guid.NewGuid(),
                Nome = "Conta de Luz",
                ValorOriginal = 200,
                ValorCorrigido = 200,
                QuantidadeDiasDeAtraso = 0,
                DataPagamento = DateTime.Now
            },
            new ContaListagemResponse
            {
                Id = Guid.NewGuid(),
                Nome = "Conta de Água",
                ValorOriginal = 150,
                ValorCorrigido = 150,
                QuantidadeDiasDeAtraso = 0,
                DataPagamento= DateTime.Now
            }
        ];

    }
}
