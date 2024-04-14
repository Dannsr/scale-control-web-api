using ScaleControl.Core.Enums;

namespace ScaleControl.Core.Entities;

public class Scale : BaseEntity
{
    public Scale(string description, IEnumerable<User> offices)
    {
        Description = description;
        IdOffices = offices.Select(x => x.Id);
        Status = ScaleStatusEnum.StandBy;
        TypeService = ScaleTypeServiceEnum.Administrative;
        Turn = ScaleTurnEnum.BusinessHours;
    }

    public string Description { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime FinishAt { get; private set; }
    public IEnumerable<int> IdOffices { get; private set; }
    public ScaleStatusEnum Status { get; private set; }
    public ScaleTypeServiceEnum TypeService { get; private set;}
    public ScaleTurnEnum Turn { get; private set; }
    
}