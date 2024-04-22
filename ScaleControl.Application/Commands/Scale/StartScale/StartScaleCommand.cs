using MediatR;

namespace ScaleControl.Application.Commands.StartScale;

public class StartScaleCommand : IRequest<Unit>
{
    public StartScaleCommand(int id)
    {
        Id = id;
    }
    public int Id { get; private set; }
}