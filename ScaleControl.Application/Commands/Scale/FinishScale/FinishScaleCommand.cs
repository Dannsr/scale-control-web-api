using MediatR;

namespace ScaleControl.Application.Commands.Scale.FinishScale;

public class FinishScaleCommand : IRequest<Unit>
{
    public FinishScaleCommand(int id)
    {
        Id = id;
    }
    
    public int Id { get; private set; }
}