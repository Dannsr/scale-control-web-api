using System.ComponentModel.DataAnnotations;

namespace ScaleControl.Core.Base;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
    }
    [Key]
    public int Id { get; private set; }
}