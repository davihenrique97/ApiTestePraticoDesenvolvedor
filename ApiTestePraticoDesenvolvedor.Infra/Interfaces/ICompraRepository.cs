using ApiTestePraticoDesenvolvedor.Domain.Dto;

namespace ApiTestePraticoDesenvolvedor.Infra.Interfaces;
public interface ICompraRepository
{
    public bool CadastrarConta(ContaDto contadto);
    public bool VerificaPagamento(DateTime dataPagamento);
    public IEnumerable<ContaDto> ListaContasCadastradas();
    public ContaDto? PesquisarConta(Guid id);
}
