using MediatR;

namespace ScaleControl.Application.Commands.Detachment.DeleteRestriction;

public class DeleteDetachmentCommand : IRequest<Unit>
{
    public DeleteDetachmentCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}