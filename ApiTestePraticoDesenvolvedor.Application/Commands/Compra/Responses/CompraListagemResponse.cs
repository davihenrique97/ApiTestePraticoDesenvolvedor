namespace ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Responses;
public class CompraListagemResponse
{
    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public double ValorOriginal { get; set; }
    public double ValorCorrigido { get; set; }
    public int QuantidadeDiasDeAtraso { get; set; }
    public DateTime DataPagamento { get; set; }
}
