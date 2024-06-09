using ApiTestePraticoDesenvolvedor.Application.Commands.Conta;
using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Perfil;
using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Responses;
using ApiTestePraticoDesenvolvedor.Domain.Dto;
using ApiTestePraticoDesenvolvedor.Infra.Interfaces;
using ApiTestePraticoDesenvolvedor.Tests.SharedKernel.Mock.Domain.Dto;
using AutoMapper;
using FluentAssertions;
using Moq;

namespace ApiTestePraticoDesenvolvedor.Tests.Application.Commands.Conta;
public class ContaServiceListarTests
{
    private readonly Mock<IContaRepository> _compraRepository;
    private readonly IMapper _mapper;

    public ContaServiceListarTests()
    {
        _compraRepository = new Mock<IContaRepository>();

        var config = new MapperConfiguration(opt =>
        {
            opt.AddProfile(new ContaServiceProfile());
        });

        _mapper = config.CreateMapper();
    }

    [Fact]
    public void DeveListarContas()
    {

        var retorno = ContaDtoMock.ContasListagem();
        var esperado = _mapper.Map<IEnumerable<ContaListagemResponse>>(retorno);

        _compraRepository.Setup(r => r.ListaContasCadastradas()).Returns(retorno);
        var compraService = new ContaService(_compraRepository.Object, _mapper);

        var result = compraService.Listar(null);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(esperado);
    }

    [Fact]
    public void DevePesquisarUmaConta()
    {
        var id = Guid.NewGuid().ToString();
        var retorno = ContaDtoMock.Conta();

        var esperado = _mapper.Map<IEnumerable<ContaListagemResponse>>(new List<ContaDto> { retorno });

        _compraRepository.Setup(r => r.PesquisarConta(It.IsAny<Guid>())).Returns(retorno);
        var compraService = new ContaService(_compraRepository.Object, _mapper);

        var result = compraService.Listar(id);

        result.Should().NotBeNull();
        result.FirstOrDefault().Should().BeEquivalentTo(esperado.FirstOrDefault());
    }
}
