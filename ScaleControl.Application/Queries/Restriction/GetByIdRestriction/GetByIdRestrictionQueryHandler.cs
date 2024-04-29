using MediatR;
using ScaleControl.Core.Repositories;

namespace ScaleControl.Application.Queries.Restriction.GetByIdRestriction;

public class GetByIdRestrictionQueryHandler : IRequestHandler<GetByIdRestrictionQuery, RestrictionDetailsViewModel>
{
    private readonly IRestrictionRepository _restrictionRepository;

    public GetByIdRestrictionQueryHandler(IRestrictionRepository restrictionRepository)
    {
        _restrictionRepository = restrictionRepository;
    }
    public async Task<RestrictionDetailsViewModel> Handle(GetByIdRestrictionQuery request, CancellationToken cancellationToken)
    {
        var restriction = await _restrictionRepository.GetRestriction(request.Enrollment);
        var user = restriction.User.FullName;
        var enrollment = restriction.User.Enrollment;
        var restrictionDetailsViewModel = new RestrictionDetailsViewModel(enrollment, restriction.StartAt,
            restriction.FinishAt, restriction.TypeEnum, restriction.Observation, restriction.SEIProcess, user);
        return restrictionDetailsViewModel;
    }
}