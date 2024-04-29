using MediatR;
using ScaleControl.Core.Enums;

namespace ScaleControl.Application.Queries.Restriction.GetByIdRestriction;

public class GetByIdRestrictionQuery : IRequest<RestrictionDetailsViewModel>
{
    public GetByIdRestrictionQuery(int enrollment)
    {
        Enrollment = enrollment;
    }

    public int Enrollment { get; private set; }
}

public class RestrictionDetailsViewModel
{
    public int Enrollment { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime FinishAt { get; private set; }
    public RestrictionTypeEnum TypeEnum { get; private set; }
    public string Observation { get; private set; }
    public int SEIProcess { get; private set; }
    public string UserName { get; private set; }

    public RestrictionDetailsViewModel(int enrollment, DateTime startAt, DateTime finishAt, RestrictionTypeEnum typeEnum, string observation, int seiProcess, string userName)
    {
        Enrollment = enrollment;
        StartAt = startAt;
        FinishAt = finishAt;
        TypeEnum = typeEnum;
        Observation = observation;
        SEIProcess = seiProcess;
        UserName = userName;
    }
}