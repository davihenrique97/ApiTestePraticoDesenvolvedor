using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Enum;
using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Responses;
using ApiTestePraticoDesenvolvedor.Application.Extensions;
using ApiTestePraticoDesenvolvedor.Application.Interfaces.Compra;
using ApiTestePraticoDesenvolvedor.Domain.Dto;
using ApiTestePraticoDesenvolvedor.Infra.Interfaces;
using AutoMapper;

namespace ApiTestePraticoDesenvolvedor.Application.Commands.Compra;
public class CompraService(ICompraRepository compraRepository, IMapper mapper) : ICompraService
{
    private readonly ICompraRepository _compraRepository = compraRepository;
    private readonly IMapper _mapper = mapper;
    public CompraIncluirResponse Incluir(CompraIncluirRequest request)
    {
        var pagamentoValido = _compraRepository
            .VerificaPagamento(request.DataPagamento);

        if (!pagamentoValido)
        {
            return new CompraIncluirResponse
            {
                Status = StatusConta.ProblemaAoIncluir,
                Menssagens = ["Problema ao Incluir a Conta.",
                              $"Já Existe Um Pagamento Com a Data {request.DataPagamento} !"]
            };
        }

        var contaDto = _mapper.Map<ContaDto>(request);

        contaDto.CalcularMultaEJuros();

        var result = _compraRepository.CadastrarConta(contaDto);

        if (!result)
        {
            return new CompraIncluirResponse
            {
                Status = StatusConta.ProblemaAoIncluir,
                Menssagens = ["Problema ao Incluir a Conta.",
                              "Conta não Inclusa!"]
            };
        }

        return new CompraIncluirResponse
        {
            Status = StatusConta.ContaIncluida,
            Menssagens = ["Conta Incluída Com Sucesso."]
        };
    }

    public IEnumerable<CompraListagemResponse> Listar(string? idConta)
    {
        IList<ContaDto> contas = new List<ContaDto>();

        if (!string.IsNullOrEmpty(idConta))
        {
            var idContaGuid = new Guid(idConta);

            var resultadoconta = _compraRepository.PesquisarConta(idContaGuid);
            if (resultadoconta != null)
            {
                contas.Add(resultadoconta);
            }

        }
        else
        {
            var resultadoContas = _compraRepository.ListaContasCadastradas();
            contas = _mapper.Map<IList<ContaDto>>(resultadoContas);
        }

        return _mapper.Map<IEnumerable<CompraListagemResponse>>(contas);
    }
}
