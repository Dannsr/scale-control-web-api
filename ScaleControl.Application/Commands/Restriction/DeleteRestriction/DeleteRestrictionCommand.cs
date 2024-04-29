using MediatR;

namespace ScaleControl.Application.Commands.Restriction.DeleteRestriction;

public class DeleteRestrictionCommand : IRequest<Unit>
{
    public DeleteRestrictionCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}