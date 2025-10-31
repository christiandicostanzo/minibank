using MongoDB.Bson.Serialization.Attributes;

namespace MiniBank.Domain;

public interface IEntity
{

}

public class EntityBase : IEntity
{
    public Guid EntityId { get; set; }
}

public class AuditableEntity : EntityBase
{
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}

