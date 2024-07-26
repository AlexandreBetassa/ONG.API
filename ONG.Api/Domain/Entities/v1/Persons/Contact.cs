using ONG.Api.Domain.Enums.v1;

namespace ONG.Api.Domain.Entities.v1.Persons
{
    public class Contact : BaseEntity
    {
        public string Number { get; set; }
        public TypeContactEnum TypeContact { get; set; }
    }
}