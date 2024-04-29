using MediatR;
using ScaleControl.Core.Repositories;

namespace ScaleControl.Application.Commands.Restriction.CreateRestriction;

public class CreateRestrictionCommandHandler : IRequestHandler<CreateRestrictionCommand, int>
{
    private readonly IRestrictionRepository _restrictionRepository;
    
    public CreateRestrictionCommandHandler(IRestrictionRepository restrictionRepository)
    {
        _restrictionRepository = restrictionRepository;
    }
    public async Task<int> Handle(CreateRestrictionCommand request, CancellationToken cancellationToken)
    {
        var restriction = new Core.Entities.Restriction(request.StartAt, request.FinishAt, request.TypeEnum, request.Observation, request.SEIProcess, request.Enrollment);
        await _restrictionRepository.AddAsync(restriction);
        await _restrictionRepository.SaveChangesAsync();
        return restriction.Id;
    }
}