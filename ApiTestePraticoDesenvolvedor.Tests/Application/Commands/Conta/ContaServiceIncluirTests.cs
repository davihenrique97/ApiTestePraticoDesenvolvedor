using ApiTestePraticoDesenvolvedor.Application.Commands.Conta;
using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Enum;
using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Perfil;
using ApiTestePraticoDesenvolvedor.Domain.Dto;
using ApiTestePraticoDesenvolvedor.Infra.Interfaces;
using ApiTestePraticoDesenvolvedor.Tests.SharedKernel.Mock.Application.Commands.Conta.Requests;
using ApiTestePraticoDesenvolvedor.Tests.SharedKernel.Mock.Application.Commands.Conta.Responses;
using AutoMapper;
using FluentAssertions;
using Moq;

namespace ApiTestePraticoDesenvolvedor.Tests.Application.Commands.Conta;
public class ContaServiceIncluirTests
{
    private readonly Mock<IContaRepository> _contaRepository;
    private readonly IMapper _mapper;

    public ContaServiceIncluirTests()
    {
        _contaRepository = new Mock<IContaRepository>();

        var config = new MapperConfiguration(opt =>
        {
            opt.AddProfile(new ContaServiceProfile());
        });

        _mapper = config.CreateMapper();
    }

    [Fact]
    public void DeveIncluirPagamento()
    {

        _contaRepository.Setup(r => r.VerificaPagamento(It.IsAny<DateTime>())).Returns(true);
        _contaRepository.Setup(r => r.CadastrarConta(It.IsAny<ContaDto>())).Returns(Guid.NewGuid);

        var compraService = new ContaService(_contaRepository.Object, _mapper);

        var result = compraService.Incluir(ContaIncluirRequestMock.GetMocked());

        result.Should().NotBeNull();

        result.Status.Should().Be(StatusConta.ContaIncluida);
        result.Menssagens.First().Should().BeEquivalentTo("Conta Incluída Com Sucesso.");
    }

    [Fact]
    public void DeveFalharAoIncluirPagamentoJaExistente()
    {
        var dataPagamento = DateTime.Now;

        var esperado = ContaIncluirResponseMock.ContaIncluirResponsePagamentoJaExistente(dataPagamento);
        var contaRequest = ContaIncluirRequestMock.GetMocked();
        contaRequest.DataPagamento = dataPagamento;

        _contaRepository.Setup(r => r.VerificaPagamento(It.IsAny<DateTime>())).Returns(false);

        var compraService = new ContaService(_contaRepository.Object, _mapper);

        var result = compraService.Incluir(contaRequest);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(esperado);
    }

    [Fact]
    public void DeveFalharAoIncluirContaNaoInclusa()
    {
        var esperado = ContaIncluirResponseMock.ContaIncluirResponseFalha();
        var contaRequest = ContaIncluirRequestMock.GetMocked();

        _contaRepository.Setup(r => r.VerificaPagamento(It.IsAny<DateTime>())).Returns(true);
        _contaRepository.Setup(r => r.CadastrarConta(It.IsAny<ContaDto>())).Returns(Guid.Empty);

        var compraService = new ContaService(_contaRepository.Object, _mapper);

        var result = compraService.Incluir(contaRequest);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(esperado);
    }
}
