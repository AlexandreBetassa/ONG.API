using MediatR;

namespace ONG.Api.Domain.Queries.v1.Persons.GetPersonByCpf
{
    public class GetPersonByCpfQuery(string cpf) : IRequest<GetPersonByCpfQueryResponse>
    {
        public string Cpf => cpf;
    }
}
