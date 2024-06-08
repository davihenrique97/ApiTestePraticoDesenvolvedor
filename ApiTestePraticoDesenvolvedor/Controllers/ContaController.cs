using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Enum;
using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Responses;
using ApiTestePraticoDesenvolvedor.Application.Interfaces.Compra;
using Microsoft.AspNetCore.Mvc;

namespace ApiTestePraticoDesenvolvedor.Api.Controllers;

[ApiController]
[Route("/")]
public class ContaController(ICompraService compraService) : ControllerBase
{
    private readonly ICompraService _compraService = compraService;

    [HttpPost]
    [Route("IncluirConta")]
    [ProducesResponseType<ContaIncluirResponse>(StatusCodes.Status201Created)]
    public IActionResult IncluirConta([FromBody] CompraIncluirRequest request)
    {

        var result = _compraService.Incluir(request);

        if (result.Status != StatusConta.ContaIncluida)
        {
            return UnprocessableEntity(result);
        }

        return Ok(result);
    }

    [HttpGet]
    [Route("Consultar")]
    [ProducesResponseType<ContaListagemResponse>(StatusCodes.Status200OK)]
    public IActionResult Consultar([FromQuery] string? id)
    {
        var compras = _compraService.Listar(id);

        if (!compras.Any())
        {
            return UnprocessableEntity("Nenhuma Conta Encontrada");
        }

        return Ok(compras);
    }
}
