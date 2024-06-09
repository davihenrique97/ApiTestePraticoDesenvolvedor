using System.Diagnostics.CodeAnalysis;
using ApiTestePraticoDesenvolvedor.Domain.Dto;
using ApiTestePraticoDesenvolvedor.Domain.Entities;
using ApiTestePraticoDesenvolvedor.Infra.DatabaseContext;
using ApiTestePraticoDesenvolvedor.Infra.Interfaces;
using AutoMapper;

namespace ApiTestePraticoDesenvolvedor.Infra.Repositories;

[ExcludeFromCodeCoverage]
public class ContaRepository(Context context, IMapper mapper) : IContaRepository
{
    private readonly Context _context = context;
    private readonly IMapper _mapper = mapper;

    public Guid CadastrarConta(ContaDto contadto)
    {
        var conta = _mapper.Map<ContaEntity>(contadto);

        _context.Conta.Add(conta);
        _context.SaveChanges();

        return conta.IdConta;
    }

    public bool VerificaPagamento(DateTime dataPagamento)
    {
        var result = _context.Conta
            .All(c => c.DataPagamento != dataPagamento);

        return result;
    }

    public IEnumerable<ContaDto> ListaContasCadastradas()
    {
        var result = _context.Conta;

        if (!result.Any())
        {
            return [];
        }

        return _mapper.Map<IEnumerable<ContaDto>>(result);

    }

    public ContaDto? PesquisarConta(Guid id)
    {
        var conta = _context.Conta.FirstOrDefault(c => c.IdConta == id);
        return _mapper.Map<ContaDto>(conta);
    }
}
