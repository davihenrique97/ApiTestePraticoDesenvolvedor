using ApiTestePraticoDesenvolvedor.Application.Commands.Compra;
using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Perfil;
using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Responses;
using ApiTestePraticoDesenvolvedor.Infra.Interfaces;
using ApiTestePraticoDesenvolvedor.Tests.SharedKernel.Mock.Domain.Dto;
using AutoMapper;
using FluentAssertions;
using Moq;

namespace ApiTestePraticoDesenvolvedor.Tests.Application.Commands.Compra;
public class CompraServiceListarTests
{
    private readonly Mock<ICompraRepository> _compraRepository;
    private readonly IMapper _mapper;

    public CompraServiceListarTests()
    {
        _compraRepository = new Mock<ICompraRepository>();

        var config = new MapperConfiguration(opt =>
        {
            opt.AddProfile(new CompraServiceProfile());
        });

        _mapper = config.CreateMapper();
    }

    [Fact]
    public void DeveListarContas()
    {

        var retorno = ContaDtoMock.ContasListagem();
        var esperado = _mapper.Map<IEnumerable<ContaListagemResponse>>(retorno);

        _compraRepository.Setup(r => r.ListaContasCadastradas()).Returns(retorno);
        var compraService = new CompraService(_compraRepository.Object, _mapper);

        var result = compraService.Listar(null);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(esperado);
    }
}
