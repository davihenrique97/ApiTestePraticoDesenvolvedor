using ApiTestePraticoDesenvolvedor.Api.Controllers;
using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Enum;
using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Requests;
using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Responses;
using ApiTestePraticoDesenvolvedor.Application.Interfaces.Conta;
using ApiTestePraticoDesenvolvedor.Tests.SharedKernel.Mock.Application.Commands.Conta.Requests;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ApiTestePraticoDesenvolvedor.Tests.Api.Controllers;
public class ContaControllerTests
{
    private readonly Mock<IContaService> _contaService;

    public ContaControllerTests()
    {
        _contaService = new Mock<IContaService>();
    }

    [Fact]
    public void DeveIncluirConta()
    {
        var contaIncluirResponse = new ContaIncluirResponse
        {
            Status = StatusConta.ContaIncluida,
            Menssagens = ["Conta Incluída Com Sucesso."]
        };

        _contaService.Setup(r => r.Incluir(It.IsAny<ContaIncluirRequest>()))
             .Returns(contaIncluirResponse);

        var controller = new ContaController(_contaService.Object);

        var result = controller.IncluirConta(ContaIncluirRequestMock.GetMocked());

        var resposta = ((OkObjectResult)result).Value as ContaIncluirResponse;

        ((OkObjectResult)result).StatusCode.Should().Be(200);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
        ((OkObjectResult)result).StatusCode.Should().Be(200);
        resposta.Should().BeEquivalentTo(contaIncluirResponse);
    }

    [Fact]
    public void DeveConsultarUmaConta()
    {
        var listaContas = new List<ContaListagemResponse> {
        new ContaListagemResponse
        {
            Id = Guid.NewGuid(),
            Nome = "Conta de Luz",
            DataPagamento = DateTime.Now,
            ValorOriginal = 250,
            ValorCorrigido = 250,
            QuantidadeDiasDeAtraso = 0
        },
        new ContaListagemResponse
        {
            Id = Guid.NewGuid(),
            Nome = "Conta de Água",
            DataPagamento = DateTime.Now,
            ValorOriginal = 150,
            ValorCorrigido = 150,
            QuantidadeDiasDeAtraso = 0
        }
        };

        _contaService.Setup(r => r.Listar(null))
             .Returns(listaContas);

        var controller = new ContaController(_contaService.Object);

        var result = controller.Consultar(null);

        var resposta = ((OkObjectResult)result).Value as IEnumerable<ContaListagemResponse>;

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
        ((OkObjectResult)result).StatusCode.Should().Be(200);
        resposta.Should().BeEquivalentTo(listaContas);
    }
}
