﻿using System.Text.Json.Serialization;
using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Enum;

namespace ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Responses;
public class ContaIncluirResponse
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public StatusConta Status { get; set; }

    public required IEnumerable<string> Menssagens { get; set; }
}