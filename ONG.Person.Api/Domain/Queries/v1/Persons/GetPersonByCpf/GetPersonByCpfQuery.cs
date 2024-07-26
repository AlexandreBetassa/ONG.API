using MediatR;

namespace ONG.Person.Api.Domain.Queries.v1.Person.GetPersonByCpf
{
    public class GetPersonByCpfQuery(string cpf) : IRequest<GetPersonByCpfQueryResponse>
    {
        public string Cpf => cpf;
    }
}
