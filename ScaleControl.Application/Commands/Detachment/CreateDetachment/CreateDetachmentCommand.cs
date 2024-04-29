using MediatR;
using ScaleControl.Core.Enums;

namespace ScaleControl.Application.Commands.Detachment.CreateDetachment;

public class CreateDetachmentCommand : IRequest<int>
{
    public DateTime StartAt { get; set; }
    public DateTime FinishAt { get; set; }
    public AbsenceTypeEnum TypeEnum { get; set; }
    public string Observation { get; set; }
    public int SEIProcess { get; set; }
    
    public int Enrollment { get; set; }
}