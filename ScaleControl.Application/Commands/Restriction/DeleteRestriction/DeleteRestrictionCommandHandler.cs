using MediatR;
using ScaleControl.Application.Commands.Detachment.DeleteRestriction;
using ScaleControl.Core.Repositories;

namespace ScaleControl.Application.Commands.Restriction.DeleteRestriction;

public class DeleteRestrictionCommandHandler : IRequestHandler<DeleteDetachmentCommand, Unit>
{
    private readonly IRestrictionRepository _restrictionRepository;
    
    public DeleteRestrictionCommandHandler(IRestrictionRepository restrictionRepository)
    {
        _restrictionRepository = restrictionRepository;
    }
    public async Task<Unit> Handle(DeleteDetachmentCommand request, CancellationToken cancellationToken)
    {
        var restriction = await _restrictionRepository.GetRestriction(request.Id);
        await _restrictionRepository.DeleteRestriction(restriction);
        await _restrictionRepository.SaveChangesAsync();
        return Unit.Value;
    }
}