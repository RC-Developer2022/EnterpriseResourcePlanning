using EnterpriseResourcePlanning.Domain.Struct;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EnterpriseResourcePlanning.Infrastructure.ConvertType;

public class CustomerIdConvert : ValueConverter<CustomerId, Guid>
{
    public CustomerIdConvert(ConverterMappingHints mappingHints = null)
        : base(
            id => id.value,
            value => new CustomerId(value),
            mappingHints)
    { }

}
