namespace ONG.Person.Api.Domain.Queries.v1.Pets.GetPetById
{
    public class GetPetByIdQueryResponse 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string Castrated { get; set; }
        public string Comments { get; set; }
        public byte[] Photo { get; set; }
    }
}
