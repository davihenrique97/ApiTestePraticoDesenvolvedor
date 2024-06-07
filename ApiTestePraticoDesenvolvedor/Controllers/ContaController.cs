using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Enum;
using ApiTestePraticoDesenvolvedor.Application.Commands.Compra.Responses;
using ApiTestePraticoDesenvolvedor.Application.Interfaces.Compra;
using Microsoft.AspNetCore.Mvc;

namespace ApiTestePraticoDesenvolvedor.Api.Controllers;

[ApiController]
public class ContaController(ICompraService compraService) : Controller
{
    private readonly ICompraService _compraService = compraService;

    [HttpPost]
    [Route("/Pagar")]
    public IActionResult PagarConta([FromBody] CompraIncluirRequest request)
    {

        var result = _compraService.Incluir(request);

        if (result.Status != StatusConta.Pago)
        {
            return UnprocessableEntity(result);
        }

        return Ok(result);
    }

    [HttpGet]
    [Route("/Consultar")]
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
