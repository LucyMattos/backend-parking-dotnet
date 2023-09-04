using EstacionamentoAPI.Domain.ViewModel;
using FluentValidation;

namespace EstacionamentoAPI.Domain.Validacoes
{
    public class VeiculoValidador : AbstractValidator<AddVeiculo>
    {
        public VeiculoValidador()
        {
            RuleFor(c => c.EmpresaId).GreaterThan(0).WithMessage("Informe a Empresa");
            RuleFor(c => c.Marca).NotNull().WithMessage("Informe a Marca");
            RuleFor(c => c.Modelo).NotNull().WithMessage("Informe o Modelo");
            RuleFor(c => c.Cor).NotNull().WithMessage("Informe a Cor");
            RuleFor(c => c.Placa).NotNull().WithMessage("Informe a Placa");
        }
    }
}
