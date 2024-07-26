using FluentValidation;

namespace ONG.Api.Domain.Commands.v1.Person.CreatePerson.Validators
{
    public class CreatePersonAddressCommandValidator : AbstractValidator<CreatePersonAddressCommand>
    {
        public CreatePersonAddressCommandValidator()
        {
            RuleFor(x => x.Street)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo Logradouro obrigatório");

            RuleFor(x => x.Neighborhood)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo Bairro obrigatório");

            RuleFor(x => x.City)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo Cidade obrigatório");

            RuleFor(x => x.Number)
                .NotNull()
                .NotEmpty()
                .WithMessage("Campo Número obrigatório");
        }
    }
}
