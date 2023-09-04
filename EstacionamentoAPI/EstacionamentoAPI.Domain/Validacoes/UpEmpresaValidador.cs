using EstacionamentoAPI.Domain.ViewModel;
using FluentValidation;

namespace EstacionamentoAPI.Domain.Validacoes
{
    public class UpEmpresaValidador : AbstractValidator<UpEmpresa>
    {
        public UpEmpresaValidador()
        {
            RuleFor(c => c.VagasParaCarros).GreaterThan(0).WithMessage("Informe o número de vagas para Carros"); ;
            RuleFor(c => c.VagasParaMotos).GreaterThan(0).WithMessage("Informe o número de vagas para Motos"); ;
            RuleFor(c => c.Nome).NotNull().WithMessage("Informe o Nome");
            RuleFor(c => c.CNPJ).NotNull().WithMessage("Informe o CNPJ");
            RuleFor(c => c.Endereco).NotNull().WithMessage("Informe o Endereço");
            RuleFor(c => c.Telefone).NotNull().WithMessage("Informe o Telefone");
        }
    }
}
