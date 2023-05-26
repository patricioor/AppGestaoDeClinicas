using GeCli.Back.Domain.Validation;

namespace GeCli.Back.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }


        protected void ValidateDomainName(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. Too short, minimum 3 characters");
            Name = name;
        }

        protected void ValidateDomainId(int id)
        {
            DomainExceptionValidation.When(id < 0, "Invalid 'id' value");
            Id = id;
        }
    }
}
