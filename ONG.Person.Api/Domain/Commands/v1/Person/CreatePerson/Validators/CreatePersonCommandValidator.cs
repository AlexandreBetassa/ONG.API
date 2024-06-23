using FluentValidation;

namespace ONG.Person.Api.Domain.Commands.v1.Person.CreatePerson.Validators
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(x => x.Address)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe um endereço");

            RuleFor(x => x.Contact)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe um telefone de contato");

            RuleFor(x => x.Cpf)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo CPF obrigatório");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo Nome obrigatório");

            RuleFor(x => x.Birthday)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo Data de nascimento obrigatório");
        }
    }
}