using ScaleControl.Core.Enums;

namespace ScaleControl.Core.Entities;

public class Scale : BaseEntity
{
    public Scale()
    {
        Offices = new List<UserScale>();      
        Status = ScaleStatusEnum.StandBy;
        TypeService = ScaleTypeServiceEnum.Administrative;
        Turn = ScaleTurnEnum.BusinessHours;
    }

    public Scale(List<UserScale> offices, ScaleStatusEnum status,
        ScaleTypeServiceEnum typeService, ScaleTurnEnum turn)
    {
        Offices = offices;
        Status = status;
        TypeService = typeService;
        Turn = turn;
    }
    public DateTime StartAt { get; private set; }
    public DateTime FinishAt { get; private set; }
    public List<UserScale> Offices { get; private set; }
    
    public List<User> OfficesNames { get; set; }
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

    public void Update(List<User> offices, ScaleStatusEnum status, ScaleTypeServiceEnum typeServiceEnum, ScaleTurnEnum turn, DateTime startAt, DateTime finishAt)
    {
        OfficesNames = offices;
        Status = status;
        TypeService = typeServiceEnum;
        Turn = turn;
        StartAt = startAt;
        FinishAt = finishAt;
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