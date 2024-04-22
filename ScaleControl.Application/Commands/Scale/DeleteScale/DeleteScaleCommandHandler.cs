using MediatR;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Commands.DeleteScale;

public class DeleteScaleCommandHandler : IRequestHandler<DeleteScaleCommand, Unit>
{
    private readonly ScaleControlDbContext _dbContext;

    public DeleteScaleCommandHandler(ScaleControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Unit> Handle(DeleteScaleCommand request, CancellationToken cancellationToken)
    {
        var scale = _dbContext.Scales.SingleOrDefault(s => s.Id == request.Id);
        scale.Cancel();
        _dbContext.Scales.Remove(scale);
        await _dbContext.SaveChangesAsync();
        return Unit.Value;
    }
}

