using FluentValidation;

namespace ONG.Api.Domain.Commands.v1.Person.CreatePerson.Validators
{
    public class CreatePersonContactCommandValidator : AbstractValidator<CreatePersonContactCommand>
    {
        public CreatePersonContactCommandValidator()
        {
            RuleFor(x => x.TypeContact)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo Tipo de contato obrigatório");

            RuleFor(x => x.Number)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo Numero de telefone obrigatório");
        }
    }
}
