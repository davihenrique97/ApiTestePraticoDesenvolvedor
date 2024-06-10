using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Requests;
using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Responses;
using ApiTestePraticoDesenvolvedor.Domain.Dto;
using AutoMapper;

namespace ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Perfil;
public class ContaServiceProfile : Profile
{
    public ContaServiceProfile()
    {
        CreateMap<ContaIncluirRequest, ContaDto>();

        CreateMap<ContaDto, ContaListagemResponse>()
            .ForMember(r => r.QuantidadeDiasDeAtraso, opt => opt.MapFrom(dto => dto.DiasAtrasados));
    }
}
