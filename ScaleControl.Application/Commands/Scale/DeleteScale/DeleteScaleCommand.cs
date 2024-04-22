using MediatR;

namespace ScaleControl.Application.Commands.DeleteScale;

public class DeleteScaleCommand : IRequest<Unit>
{
    public DeleteScaleCommand(int id)
    {
        Id = id;
    }
    public int Id { get; private set; }
}