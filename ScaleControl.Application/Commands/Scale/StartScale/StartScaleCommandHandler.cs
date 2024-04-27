using MediatR;
using ScaleControl.Core.Repositories;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Commands.StartScale;

public class StartScaleCommandHandler : IRequestHandler<StartScaleCommand, Unit>
{
    private readonly IScaleRepository _scaleRepository;
    
    public StartScaleCommandHandler(IScaleRepository scaleRepository)
    {
        _scaleRepository = scaleRepository;
    }

    public async Task<Unit> Handle(StartScaleCommand request, CancellationToken cancellationToken)
    {
        var scale = await _scaleRepository.GetScale(request.Id);
        scale.Start();
        await _scaleRepository.SaveChangesAsync();
        return Unit.Value;
    }
}