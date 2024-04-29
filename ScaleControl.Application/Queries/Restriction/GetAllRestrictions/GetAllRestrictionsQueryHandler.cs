using MediatR;
using ScaleControl.Application.Queries.Detachment.GetByIdDetachment;
using ScaleControl.Core.Repositories;

namespace ScaleControl.Application.Queries.Restriction.GetAllRestrictions;

public class GetAllRestrictionsQueryHandler : IRequestHandler<GetAllRestrictionsQuery, List<RestrictionViewModel>>
{
    private readonly IRestrictionRepository _restrictionRepository;

    public GetAllRestrictionsQueryHandler(IRestrictionRepository restrictionRepository)
    {
        _restrictionRepository = restrictionRepository;
    }
    
    public async Task<List<RestrictionViewModel>> Handle(GetAllRestrictionsQuery request, CancellationToken cancellationToken)
    {
        var restriction = await _restrictionRepository.GetAll();
        List<RestrictionViewModel> restrictionViewModel = new List<RestrictionViewModel>();
        foreach (var item in restriction)
        {
            var enrollment = item.User.Enrollment;
            var fullName = item.User.FullName;
            restrictionViewModel.Add(new RestrictionViewModel(fullName,enrollment, item.StartAt, item.FinishAt, item.TypeEnum));
        }
        return restrictionViewModel; 
    }
}