using MediatR;
using ScaleControl.Core.Entities;
using ScaleControl.Core.Repositories;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Commands.CreateScale;

public class CreateScaleCommandHandler : IRequestHandler<CreateScaleCommand, int>
{
    private readonly IScaleRepository _scaleRepository;
    
    public CreateScaleCommandHandler(IScaleRepository scaleRepository)
    {
        _scaleRepository = scaleRepository;
    }
    
    public async Task<int> Handle(CreateScaleCommand request, CancellationToken cancellationToken)
    { 
        var scale = new Core.Entities.Scale(request.IdOffices, request.Status, request.TypeService, request.Turn);
        await _scaleRepository.AddAsync(scale);
        await _scaleRepository.SaveChangesAsync();
        return scale.Id;
    }
}