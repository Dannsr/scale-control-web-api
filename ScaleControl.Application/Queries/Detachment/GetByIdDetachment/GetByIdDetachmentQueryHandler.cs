using MediatR;
using ScaleControl.Core.Repositories;

namespace ScaleControl.Application.Queries.Detachment.GetByIdDetachment;

public class GetByIdDetachmentQueryHandler : IRequestHandler<GetByIdDetachmentQuery, DetachmentDetailsViewModel>
{
    private readonly IDetachmentRepository _detachmentRepository;

    public GetByIdDetachmentQueryHandler(IDetachmentRepository detachmentRepository)
    {
        _detachmentRepository = detachmentRepository;
    }
    public async Task<DetachmentDetailsViewModel> Handle(GetByIdDetachmentQuery request, CancellationToken cancellationToken)
    {
        var detachment = await _detachmentRepository.GetDetachment(request.Enrollment);
        var enrollment = detachment.User.Enrollment;
        var fullName = detachment.User.FullName;
        var detachmentDetailsViewModel = new DetachmentDetailsViewModel(enrollment, detachment.StartAt,
            detachment.FinishAt, detachment.TypeEnum, detachment.Observation, detachment.SEIProcess, fullName);
        return detachmentDetailsViewModel;
    }
}