using MediatR;
using ScaleControl.Core.Enums;

namespace ScaleControl.Application.Queries.Detachment.GetByIdDetachment;

public class GetByIdDetachmentQuery : IRequest<DetachmentDetailsViewModel>
{
    public GetByIdDetachmentQuery(int enrollment)
    {
        Enrollment = enrollment;
    }

    public int Enrollment { get; private set; }
}

public class DetachmentDetailsViewModel
{
    public int Enrollment { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime FinishAt { get; private set; }
    public AbsenceTypeEnum TypeEnum { get; private set; }
    public string Observation { get; private set; }
    public int SEIProcess { get; private set; }
    public string OfficeName { get; private set; }

    public DetachmentDetailsViewModel(int enrollment, DateTime startAt, DateTime finishAt, AbsenceTypeEnum typeEnum, string observation, int seiProcess, string office)
    {
        Enrollment = enrollment;
        StartAt = startAt;
        FinishAt = finishAt;
        TypeEnum = typeEnum;
        Observation = observation;
        SEIProcess = seiProcess;
        OfficeName = office;
    }
}