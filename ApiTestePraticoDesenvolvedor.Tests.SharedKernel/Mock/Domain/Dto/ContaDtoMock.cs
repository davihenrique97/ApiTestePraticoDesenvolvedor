﻿using ApiTestePraticoDesenvolvedor.Domain.Dto;

namespace ApiTestePraticoDesenvolvedor.Tests.SharedKernel.Mock.Domain.Dto
{
    public static class ContaDtoMock
    {
        public static ContaDto GetMocked()
        {
            return new ContaDto
            {
                Id = Guid.NewGuid(),
                Nome = "Conta de Luz",
                DataPagamento = DateTime.Now,
                DataVencimento = DateTime.Now,
                ValorOriginal = 200,
                ValorCorrigido = 200,
                DiasAtrasados = 0
            };
        }
    }
}