using MediatR;
using ScaleControl.Core.Repositories;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Commands.DeleteScale;

public class DeleteScaleCommandHandler : IRequestHandler<DeleteScaleCommand, Unit>
{
    private readonly IScaleRepository _scaleRepository;
    
    public DeleteScaleCommandHandler(IScaleRepository scaleRepository)
    {
        _scaleRepository = scaleRepository;
    }

    
    public async Task<Unit> Handle(DeleteScaleCommand request, CancellationToken cancellationToken)
    {
        var scale = await _scaleRepository.GetScale(request.Id);
        scale.Cancel();
        await _scaleRepository.DeleteScale(scale);
        await _scaleRepository.SaveChangesAsync();
        return Unit.Value;
    }
}

