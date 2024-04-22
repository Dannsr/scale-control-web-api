using MediatR;
using ScaleControl.Core.Entities;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Commands.CreateScale;

public class CreateScaleCommandHandler : IRequestHandler<CreateScaleCommand, int>
{
    private readonly ScaleControlDbContext _dbContext;

    public CreateScaleCommandHandler(ScaleControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int> Handle(CreateScaleCommand request, CancellationToken cancellationToken)
    { 
        var scale = new Core.Entities.Scale(request.IdOffices, request.Status, request.TypeService, request.Turn);
        await _dbContext.Scales.AddAsync(scale);
        await _dbContext.SaveChangesAsync();
        return scale.Id;
    }
}