using MediatR;
using ScaleControl.Core.Enums;

namespace ScaleControl.Application.Queries.Detachment.GetAllDetachment;

public class GetAllDetachmentQuery : IRequest<List<DetachmentViewModel>>
{
    public GetAllDetachmentQuery(string query)
    {
        Query = query;
    }

    public string Query { get; private set; }
}

public class DetachmentViewModel
{
    public DetachmentViewModel(string fullName,int enrollment, DateTime startAt, DateTime finishAt, AbsenceTypeEnum typeEnum)
    {
        FullName = fullName;
        Enrollment = enrollment;
        StartAt = startAt;
        FinishAt = FinishAt;
        TypeEnum = typeEnum;
    }

    public string FullName { get; private set; }
    public int Enrollment { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime FinishAt { get; private set; }
    public AbsenceTypeEnum TypeEnum { get; private set; }
}