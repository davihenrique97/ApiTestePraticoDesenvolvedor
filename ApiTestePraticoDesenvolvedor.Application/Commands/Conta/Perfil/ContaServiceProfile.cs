using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Requests;
using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Responses;
using ApiTestePraticoDesenvolvedor.Domain.Dto;
using AutoMapper;

namespace ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Perfil;
public class ContaServiceProfile : Profile
{
    public ContaServiceProfile()
    {
        CreateMap<ContaIncluirRequest, ContaDto>()
            .ForMember(dto => dto.Nome, opt => opt.MapFrom(r => r.Nome))
            .ForMember(dto => dto.ValorOriginal, opt => opt.MapFrom(r => r.ValorOriginal))
            .ForMember(dto => dto.DataVencimento, opt => opt.MapFrom(r => r.DataVencimento))
            .ForMember(dto => dto.DataPagamento, opt => opt.MapFrom(r => r.DataPagamento));

        CreateMap<ContaDto, ContaListagemResponse>()
            .ForMember(r => r.QuantidadeDiasDeAtraso, opt => opt.MapFrom(dto => dto.DiasAtrasados));
    }
}
