namespace ScaleControl.Core.Base;

public abstract class BaseEnumEntity : BaseEntity
{
    public string Name { get; set; }
    public string Sigla { get; set; }
    public string Description { get; set; }
}