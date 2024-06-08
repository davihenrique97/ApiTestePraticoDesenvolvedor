using ApiTestePraticoDesenvolvedor.Api.Controllers;
using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Enum;
using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Requests;
using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Responses;
using ApiTestePraticoDesenvolvedor.Application.Interfaces.Conta;
using ApiTestePraticoDesenvolvedor.Tests.SharedKernel.Mock.Application.Commands.Conta.Requests;
using ApiTestePraticoDesenvolvedor.Tests.SharedKernel.Mock.Application.Commands.Conta.Responses;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ApiTestePraticoDesenvolvedor.Tests.Api.Controllers;
public class ContaControllerTests
{
    private readonly Mock<IContaService> _contaRepository;

    public ContaControllerTests()
    {
        _contaRepository = new Mock<IContaService>();
    }

    [Fact]
    public void DeveIncluirConta()
    {
        _contaRepository.Setup(r => r.Incluir(It.IsAny<ContaIncluirRequest>()))
             .Returns(ContaIncluirResponseMock.ContaInclida);

        var controller = new ContaController(_contaRepository.Object);

        var result = controller.IncluirConta(ContaIncluirRequestMock.GetMocked());

        var resposta = ((OkObjectResult)result).Value as ContaIncluirResponse;

        ((OkObjectResult)result).StatusCode.Should().Be(200);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
        ((OkObjectResult)result).StatusCode.Should().Be(200);
        resposta!.Status.Should().Be(StatusConta.ContaIncluida);
        resposta!.Menssagens.Should().BeEquivalentTo("Conta Incluída Com Sucesso.");

    }
}
