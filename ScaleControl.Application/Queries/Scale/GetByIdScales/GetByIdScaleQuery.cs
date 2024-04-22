using MediatR;
using ScaleControl.Core.Enums;

namespace ScaleControl.Application.Queries.Scale.GetByIdScales;

public class GetByIdScaleQuery : IRequest<ScaleDetailsViewModel>
{
    public GetByIdScaleQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}

public class ScaleDetailsViewModel
{
    public ScaleDetailsViewModel(int id,ScaleTypeServiceEnum typeServiceEnum, DateTime startAt, DateTime finishAt, ScaleStatusEnum status, List<string> officesFullNames)
    {
        Id = id;
        TypeServiceEnum = typeServiceEnum;
        StartAt = startAt;
        FinishAt = finishAt;
        Status = status;
        OfficesFullNames = officesFullNames;
    }

    public int Id { get; private set; }
    public ScaleTypeServiceEnum TypeServiceEnum { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime FinishAt { get; private set; }
    public ScaleStatusEnum Status { get; private set; }
    public List<string> OfficesFullNames { get; private set; }
    
    
    
}