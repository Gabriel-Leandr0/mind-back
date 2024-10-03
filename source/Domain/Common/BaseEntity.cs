using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Domain.Common;

public abstract class BaseEntity
{
    public long Id { get; set; }
}
