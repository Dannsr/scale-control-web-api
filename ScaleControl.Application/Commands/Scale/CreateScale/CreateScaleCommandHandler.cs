using MediatR;
using ScaleControl.Application.Commands.CreateScale;
using ScaleControl.Core.Repositories;

namespace ScaleControl.Application.Commands.Scale.CreateScale;

public class CreateScaleCommandHandler : IRequestHandler<CreateScaleCommand, int>
{
    private readonly IScaleRepository _scaleRepository;
    
    public CreateScaleCommandHandler(IScaleRepository scaleRepository)
    {
        _scaleRepository = scaleRepository;
    }
    
    public async Task<int> Handle(CreateScaleCommand request, CancellationToken cancellationToken)
    {
        var scale = new Core.Entities.Scale(request.Enrollments, request.Status, request.TypeService, request.Turn, request.StartAt, request.FinishAt, request.Observation);
        await _scaleRepository.AddAsync(scale);
        await _scaleRepository.SaveChangesAsync();
        return scale.Id;
    }
}