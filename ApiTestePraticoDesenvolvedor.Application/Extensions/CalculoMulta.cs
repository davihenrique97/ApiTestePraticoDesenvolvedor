using ApiTestePraticoDesenvolvedor.Domain.Dto;

namespace ApiTestePraticoDesenvolvedor.Application.Extensions;
public static class CalculoMulta
{
    private static double CalcularMulta(ContaDto contaDto, int diasCorridos)
    {
        const double SEM_MULTA = 0;

        if (diasCorridos == SEM_MULTA)
        {
            return SEM_MULTA;
        }

        if (diasCorridos <= 3)
        {
            return contaDto.ValorOriginal * 0.02;
        }

        if (diasCorridos <= 10)
        {
            return contaDto.ValorOriginal * 0.03;
        }
        if (diasCorridos > 10)
        {
            return contaDto.ValorOriginal * 0.05;
        }

        return SEM_MULTA;
    }

    private static double CalcularJuros(ContaDto contaDto, int diasCorridos)
    {
        const double SEM_JUROS = 0;

        if (diasCorridos == SEM_JUROS)
        {
            return SEM_JUROS;
        }

        if (diasCorridos <= 3)
        {
            return contaDto.ValorOriginal * 0.01 * diasCorridos;
        }

        if (diasCorridos <= 10)
        {
            return contaDto.ValorOriginal * 0.02 * diasCorridos;
        }

        if (diasCorridos > 10)
        {
            return contaDto.ValorOriginal * 0.05 * diasCorridos;
        }

        return SEM_JUROS;

    }

    public static ContaDto CalcularMultaEJuros(this ContaDto contaDto)
    {
        const int NENHUM_DIA_EM_ATRASSO = 0;

        var diasCorridos = (contaDto.DataPagamento - contaDto.DataVencimento).Days;

        if (diasCorridos <= NENHUM_DIA_EM_ATRASSO)
        {
            contaDto.DiasAtrasados = NENHUM_DIA_EM_ATRASSO;
            contaDto.ValorCorrigido = contaDto.ValorOriginal;
            return contaDto;
        }

        contaDto.DiasAtrasados = diasCorridos;

        var multa = CalcularMulta(contaDto, diasCorridos);
        var juros = CalcularJuros(contaDto, diasCorridos);

        var multaEjuros = multa + juros;

        contaDto.ValorCorrigido = contaDto.ValorOriginal + multaEjuros;

        return contaDto;
    }
}
