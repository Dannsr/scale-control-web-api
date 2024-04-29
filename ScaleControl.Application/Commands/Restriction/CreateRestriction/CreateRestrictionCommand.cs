using MediatR;
using ScaleControl.Core.Enums;

namespace ScaleControl.Application.Commands.Restriction.CreateRestriction;

public class CreateRestrictionCommand : IRequest<int>
{
    public DateTime StartAt { get; set; }
    public DateTime FinishAt { get; set; }
    public RestrictionTypeEnum TypeEnum { get; set; }
    public string Observation { get; set; }
    public int SEIProcess { get; set; }
    
    public int Enrollment { get; set; }
}