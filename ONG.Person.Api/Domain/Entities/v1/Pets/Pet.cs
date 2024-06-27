namespace ONG.Person.Api.Domain.Entities.v1.Pet
{
    public class Pet : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string Castrated { get; set; }
        public string Comments { get; set; }
        public byte[] Photo { get; set; }
    }
}
