using MediatR;
using ScaleControl.Core.Repositories;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Commands.UpdateScale;

public class UpdateScaleCommandHandler : IRequestHandler<UpdateScaleCommand, Unit>
{
    private readonly IScaleRepository _scaleRepository;
    
    public UpdateScaleCommandHandler(IScaleRepository scaleRepository)
    {
        _scaleRepository = scaleRepository;
    }


    public async Task<Unit> Handle(UpdateScaleCommand request, CancellationToken cancellationToken)
    {
        var scale = await _scaleRepository.GetScale(request.Id);
        scale.Update(request.IdOffices, request.Status, request.TypeService, request.Turn, request.FinishAt,
            request.FinishAt);
        await _scaleRepository.SaveChangesAsync();
        return Unit.Value;
    }
}
