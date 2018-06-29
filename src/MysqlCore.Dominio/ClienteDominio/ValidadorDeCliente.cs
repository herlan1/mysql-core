using FluentValidation;
using MysqlCore.Dominio.Validadores;

namespace MysqlCore.Dominio.ClienteDominio
{
    public class ValidadorDeCliente : AbstractValidator<Cliente>
    {
        public ValidadorDeCliente()
        {
            RuleSet(RegrasDeValidacao.INCLUIR, () =>
            {
                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .WithMessage("Informe o nome do Cliente!");

                RuleFor(c => c.Documento)
                    .NotEmpty()
                    .WithMessage("Informe o Documento do Cliente!");
            });
        }
    }
}
