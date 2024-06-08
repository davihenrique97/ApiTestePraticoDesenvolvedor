using ApiTestePraticoDesenvolvedor.Application.Commands.Compra;
using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Enum;
using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Perfil;
using ApiTestePraticoDesenvolvedor.Domain.Dto;
using ApiTestePraticoDesenvolvedor.Infra.Interfaces;
using ApiTestePraticoDesenvolvedor.Tests.SharedKernel.Mock.Application.Commands.Compra.Requests;
using ApiTestePraticoDesenvolvedor.Tests.SharedKernel.Mock.Application.Commands.Compra.Responses;
using AutoMapper;
using FluentAssertions;
using Moq;

namespace ApiTestePraticoDesenvolvedor.Tests.Application.Commands.Compra;
public class CompraServiceTests
{
    private readonly Mock<ICompraRepository> _compraRepository;
    private readonly IMapper _mapper;

    public CompraServiceTests()
    {
        _compraRepository = new Mock<ICompraRepository>();

        var config = new MapperConfiguration(opt =>
        {
            opt.AddProfile(new CompraServiceProfile());
        });

        _mapper = config.CreateMapper();
    }

    [Fact]
    public void DeveIncluirPagamento()
    {

        _compraRepository.Setup(r => r.CadastrarConta(It.IsAny<ContaDto>())).Returns(true);
        _compraRepository.Setup(r => r.VerificaPagamento(It.IsAny<DateTime>())).Returns(true);

        var compraService = new CompraService(_compraRepository.Object, _mapper);

        var result = compraService.Incluir(CompraIncluirRequestMock.GetMocked());

        result.Should().NotBeNull();

        result.Status.Should().Be(StatusConta.ContaIncluida);
        result.Menssagens.First().Should().BeEquivalentTo("Conta Incluída Com Sucesso.");
    }

    [Fact]
    public void DeveFalharAoIncluirPagamentoJaExistente()
    {
        var dataPagamento = DateTime.Now;

        var esperado = CompraIncluirResponseMock.PagamentoJaExistente(dataPagamento);
        var contaRequest = CompraIncluirRequestMock.GetMocked();
        contaRequest.DataPagamento = dataPagamento;

        _compraRepository.Setup(r => r.VerificaPagamento(It.IsAny<DateTime>())).Returns(false);

        var compraService = new CompraService(_compraRepository.Object, _mapper);

        var result = compraService.Incluir(contaRequest);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(esperado);
    }
}
