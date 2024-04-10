using System.ComponentModel.DataAnnotations;
using EnterpriseResourcePlanning.Domain.Struct;

namespace EnterpriseResourcePlanning.Domain.Abstractions;

public abstract class Entity
{
    [Key]
    public CustomerId Id { get; set; }

    protected Entity()
    {
        Id =  CustomerId.NewGuidCustomerId();
    }
}
