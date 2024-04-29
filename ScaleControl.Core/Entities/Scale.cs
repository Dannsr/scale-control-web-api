using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;
using ScaleControl.Core.Base;
using ScaleControl.Core.Enums;

namespace ScaleControl.Core.Entities;

public class Scale : BaseEntity
{


    //public Scale(List<int> enrollments, DateTime startAt, DateTime finishAt, string observation)
    //{
    //    Users.Find(u => u.Enrollment == enrollments.FirstOrDefault());
    //    Status = ScaleStatusEnum.StandBy;
    //    StartAt = startAt;
    //    FinishAt = finishAt;
    //    Observation = observation;
    //    TypeService = ScaleTypeServiceEnum.Administrative;
    //    Turn = ScaleTurnEnum.BusinessHours;
    //}

    public Scale(List<int> enrollments,ScaleStatusEnum status,
        ScaleTypeServiceEnum typeService, ScaleTurnEnum turn, DateTime startAt, DateTime finishAt, string observation)
    {
        Users.Find(u => u.Enrollment == enrollments.FirstOrDefault());
        Status = status;
        TypeService = typeService;
        Turn = turn;
        StartAt = startAt;
        FinishAt = finishAt;
        Observation = observation;
    }
    
    public string Observation { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime FinishAt { get; private set; }
    
    [ForeignKey("Id")]
    public List<User> Users { get; set; }
    public ScaleStatusEnum Status { get; private set; }
    public ScaleTypeServiceEnum TypeService { get; private set;}
    public ScaleTurnEnum Turn { get; private set; }
    
    public DateTime FinishedAt { get; set; }

    //public void Cancel()
    //{
    //    if (Status == ScaleStatusEnum.StandBy || Status == ScaleStatusEnum.InProgress ||
    //        Status == ScaleStatusEnum.Started)
    //    {
    //        Status = ScaleStatusEnum.Cancelled;
    //    }
    //}

    //public void Finish()
    //{
    //    if (Status == ScaleStatusEnum.InProgress)
    //    {
    //        Status = ScaleStatusEnum.Finished;
    //        FinishedAt = DateTime.Now;
    //    }
    //}

    //public void Update(ScaleStatusEnum status, ScaleTypeServiceEnum typeServiceEnum, ScaleTurnEnum turn, DateTime startAt, DateTime finishAt)
    //{
    //    Status = status;
    //    TypeService = typeServiceEnum;
    //    Turn = turn;
    //    StartAt = startAt;
    //    FinishAt = finishAt;
    //}

    //public void Start()
    //{
    //    if (Status == ScaleStatusEnum.StandBy)
    //    {
    //        Status = ScaleStatusEnum.Started;
    //        StartAt = DateTime.Now;
    //    }
    //}
}