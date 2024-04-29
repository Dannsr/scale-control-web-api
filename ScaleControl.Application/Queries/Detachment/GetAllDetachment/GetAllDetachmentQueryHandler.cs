using MediatR;
using ScaleControl.Core.Repositories;


namespace ScaleControl.Application.Queries.Detachment.GetAllDetachment;

public class GetAllDetachmentQueryHandler : IRequestHandler<GetAllDetachmentQuery, List<DetachmentViewModel>>
{
    private readonly IDetachmentRepository _detachmentRepository;

    public GetAllDetachmentQueryHandler(IDetachmentRepository detachmentRepository)
    {
        _detachmentRepository = detachmentRepository;
    }
    
    public async Task<List<DetachmentViewModel>> Handle(GetAllDetachmentQuery request, CancellationToken cancellationToken)
    {
        var detachment = await _detachmentRepository.GetAll();
        var detachmentViewModels = new List<DetachmentViewModel>();

        foreach (var enrollment in detachment)
        {
            var officeNames = enrollment.User.FullName;
            var enrollmentNumber = enrollment.User.Enrollment;

            detachmentViewModels.Add(new DetachmentViewModel(officeNames, enrollmentNumber, enrollment.StartAt, enrollment.FinishAt, enrollment.TypeEnum));
        }

        return detachmentViewModels;
    }
}