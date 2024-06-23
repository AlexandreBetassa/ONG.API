using ONG.Person.Api.Domain.Enums.v1;

namespace ONG.Person.Api.Domain.Entities.v1
{
    public class Contact : BaseEntity
    {
        public string Number { get; set; }
        public TypeContactEnum TypeContact { get; set; }
    }
}