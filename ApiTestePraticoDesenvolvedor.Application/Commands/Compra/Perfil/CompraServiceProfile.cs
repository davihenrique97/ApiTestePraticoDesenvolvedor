using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Responses;
using ApiTestePraticoDesenvolvedor.Domain.Dto;
using AutoMapper;

namespace ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Perfil;
public class CompraServiceProfile : Profile
{
    public CompraServiceProfile()
    {
        CreateMap<CompraIncluirRequest, ContaDto>()
            .ForMember(dto => dto.Nome, opt => opt.MapFrom(r => r.Nome))
            .ForMember(dto => dto.ValorOriginal, opt => opt.MapFrom(r => r.ValorOriginal))
            .ForMember(dto => dto.DataVencimento, opt => opt.MapFrom(r => r.DataVencimento))
            .ForMember(dto => dto.DataPagamento, opt => opt.MapFrom(r => r.DataPagamento));

        CreateMap<ContaDto, CompraListagemResponse>()
            .ForMember(r => r.QuantidadeDiasDeAtraso, opt => opt.MapFrom(dto => dto.DiasAtrasados));
    }
}
