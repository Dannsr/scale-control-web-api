using System.Runtime.InteropServices.JavaScript;
using MediatR;
using ScaleControl.Core.Enums;

namespace ScaleControl.Application.Queries.Restriction.GetAllRestrictions;

public class GetAllRestrictionsQuery : IRequest<List<RestrictionViewModel>>
{
    public GetAllRestrictionsQuery(string query)
    {
        Query = query;
    }

    public string Query { get; private set; }
}

public class RestrictionViewModel
{
    public RestrictionViewModel(string fullName,int enrollment, DateTime startAt, DateTime finishAt, RestrictionTypeEnum typeEnum)
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
    public RestrictionTypeEnum TypeEnum { get; private set; }
}
