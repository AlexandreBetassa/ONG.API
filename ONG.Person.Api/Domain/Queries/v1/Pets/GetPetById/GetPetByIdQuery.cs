using MediatR;

namespace ONG.Person.Api.Domain.Queries.v1.Pets.GetPetById
{
    public class GetPetByIdQuery(string id) : IRequest<GetPetByIdQueryResponse>
    {
        public string Id { get; set; } = id;
    }
}
