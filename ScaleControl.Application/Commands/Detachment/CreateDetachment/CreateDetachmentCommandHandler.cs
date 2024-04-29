using MediatR;
using ScaleControl.Core.Repositories;

namespace ScaleControl.Application.Commands.Detachment.CreateDetachment;

public class CreateDetachmentCommandHandler : IRequestHandler<CreateDetachmentCommand, int>
{
    private readonly IDetachmentRepository _detachmentRepository;
    
    public CreateDetachmentCommandHandler(IDetachmentRepository detachmentRepository)
    {
        _detachmentRepository = detachmentRepository;
    }
    public async Task<int> Handle(CreateDetachmentCommand request, CancellationToken cancellationToken)
    {
        var detachment = new Core.Entities.Detachment(request.StartAt, request.FinishAt, request.TypeEnum, request.Observation, request.SEIProcess, request.Enrollment);
        await _detachmentRepository.AddAsync(detachment); 
        await _detachmentRepository.SaveChangesAsync();
        return detachment.Id;
    }
}