using System.Runtime.InteropServices.JavaScript;
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

    public Scale(string description, IEnumerable<User> offices, ScaleStatusEnum status,
        ScaleTypeServiceEnum typeService, ScaleTurnEnum turn)
    {
        Description = description;
        IdOffices = offices.Select(x => x.Id);
        Status = status;
        TypeService = typeService;
        Turn = turn;
    }

    public string Description { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime FinishAt { get; private set; }
    public IEnumerable<int> IdOffices { get; private set; }
    public ScaleStatusEnum Status { get; private set; }
    public ScaleTypeServiceEnum TypeService { get; private set;}
    public ScaleTurnEnum Turn { get; private set; }
    
    public DateTime FinishedAt { get; set; }

    public void Cancel()
    {
        if (Status == ScaleStatusEnum.StandBy || Status == ScaleStatusEnum.InProgress ||
            Status == ScaleStatusEnum.Started)
        {
            Status = ScaleStatusEnum.Cancelled;
        }
    }

    public void Finish()
    {
        if (Status == ScaleStatusEnum.InProgress)
        {
            Status = ScaleStatusEnum.Finished;
            FinishedAt = DateTime.Now;
        }
    }

    public void Start()
    {
        if (Status == ScaleStatusEnum.StandBy)
        {
            Status = ScaleStatusEnum.Started;
            StartAt = DateTime.Now;
        }
    }
}