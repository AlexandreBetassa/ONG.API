using MediatR;

namespace ONG.Person.Api.Domain.Queries.v1.GetPersonByCpf
{
    public class GetPersonByCpfQuery (string cpf) : IRequest<GetPersonByCpfQueryResponse>
    {
        public string Cpf => cpf;
    }
}
