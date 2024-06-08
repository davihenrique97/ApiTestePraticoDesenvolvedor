using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Requests;
using FluentValidation;

namespace ApiTestePraticoDesenvolvedor.Application.Validations;
public class ContaValidator : AbstractValidator<ContaIncluirRequest>
{
    public ContaValidator()
    {
        RuleFor(c => c.Nome)
            .NotNull()
            .WithMessage("Campo Nome Não Pode Ser Nulo");

        When(c => c.Nome is not null, () =>
        {
            RuleFor(c => c.Nome).NotEmpty().WithMessage("Campo Nome Não Pode Ser Vázio.");
        });

        RuleFor(c => c.ValorOriginal)
            .NotNull()
            .WithMessage("Campo Valor Original Não Pode Ser Nulo.");

        RuleFor(c => c.ValorOriginal)
            .Must(c => c > 0)
            .WithMessage("Campo Valor Original Inválido.");

        RuleFor(c => c.DataVencimento)
            .NotEmpty()
            .WithMessage("Campo Valor Data Vencimento Obrigatória.");

        RuleFor(c => c.DataPagamento)
            .NotEmpty()
            .WithMessage("Campo Valor Data Pagamento Inválida.");
    }
}
