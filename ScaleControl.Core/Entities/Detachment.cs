using System.ComponentModel.DataAnnotations.Schema;
using ScaleControl.Core.Base;
using ScaleControl.Core.Enums;

namespace ScaleControl.Core.Entities;

public class Detachment : BaseEntity
{
    public DateTime StartAt { get; private set; }
    public DateTime FinishAt { get; private set; }
    public AbsenceTypeEnum TypeEnum { get; private set; }
    public string Observation { get; private set; }
    public int SEIProcess { get; private set; }
    
    [ForeignKey("Id")]
    public User User { get; private set; }

    public Detachment(DateTime startAt, DateTime finishAt, AbsenceTypeEnum typeEnum, string observation, int seiProcess, int enrollment)
    {
        User.Enrollment = enrollment;
        StartAt = startAt;
        FinishAt = finishAt;
        TypeEnum = typeEnum;
        Observation = observation;
        SEIProcess = seiProcess;
    }
}