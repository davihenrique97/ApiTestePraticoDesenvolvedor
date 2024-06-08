namespace ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Responses;

public class CompraIncluirRequest
{
    public string? Nome { get; set; }
    public double? ValorOriginal { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime DataPagamento { get; set; }
}
