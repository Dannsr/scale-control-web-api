using MediatR;
using ScaleControl.Core.Repositories;

namespace ScaleControl.Application.Commands.Detachment.DeleteRestriction;

public class DeleteDetachmentCommandHandler : IRequestHandler<DeleteDetachmentCommand, Unit>
{
    private readonly IDetachmentRepository _detachmentRepository;
    
    public DeleteDetachmentCommandHandler(IDetachmentRepository detachmentRepository)
    {
        _detachmentRepository = detachmentRepository;
    }
    public async Task<Unit> Handle(DeleteDetachmentCommand request, CancellationToken cancellationToken)
    {
        var detachment = await _detachmentRepository.GetDetachment(request.Id);
        await _detachmentRepository.DeleteDetachment(detachment);
        await _detachmentRepository.SaveChangesAsync();
        return Unit.Value;
    }
}