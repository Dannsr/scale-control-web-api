using MediatR;
using ScaleControl.Core.Repositories;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Commands.Scale.FinishScale;

public class FinishScaleCommandHandler : IRequestHandler<FinishScaleCommand, Unit>
{
    private readonly IScaleRepository _scaleRepository;
    
    public FinishScaleCommandHandler(IScaleRepository scaleRepository)
    {
        _scaleRepository = scaleRepository;
    }
    public async Task<Unit> Handle(FinishScaleCommand request, CancellationToken cancellationToken)
    {
        var scale = await _scaleRepository.GetScale(request.Id);
        scale.Finish();
        await _scaleRepository.SaveChangesAsync();
        return Unit.Value;
    }
}