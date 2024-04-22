using MediatR;
using ScaleControl.Core.Entities;
using ScaleControl.Core.Enums;


namespace ScaleControl.Application.Commands.CreateScale;

public class CreateScaleCommand : IRequest<int>
{
    public List<UserScale> IdOffices { get; set; }
    public ScaleStatusEnum Status { get; set; }
    public ScaleTypeServiceEnum TypeService { get; set;}
    public ScaleTurnEnum Turn { get; set; }
    
    public DateTime StartAt { get; set; }
    public DateTime FinishAt { get; set; }
}