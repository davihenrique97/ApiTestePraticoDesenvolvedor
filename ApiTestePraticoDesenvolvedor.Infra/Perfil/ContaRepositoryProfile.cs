using System.Diagnostics.CodeAnalysis;
using ApiTestePraticoDesenvolvedor.Domain.Dto;
using ApiTestePraticoDesenvolvedor.Domain.Entities;
using AutoMapper;

namespace ApiTestePraticoDesenvolvedor.Infra.Perfil;

[ExcludeFromCodeCoverage]
public class ContaRepositoryProfile : Profile
{
    public ContaRepositoryProfile()
    {
        CreateMap<ContaDto, ContaEntity>()
            .ForMember(e => e.IdConta, opt => opt.MapFrom(e => Guid.NewGuid()));

        CreateMap<ContaEntity, ContaDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(e => e.IdConta));
    }
}
