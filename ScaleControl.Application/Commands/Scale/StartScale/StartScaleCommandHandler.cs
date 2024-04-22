using MediatR;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Commands.StartScale;

public class StartScaleCommandHandler : IRequestHandler<StartScaleCommand, Unit>
{
    private readonly ScaleControlDbContext _dbContext;

    public StartScaleCommandHandler(ScaleControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(StartScaleCommand request, CancellationToken cancellationToken)
    {
        var scale = _dbContext.Scales.SingleOrDefault(s => s.Id == request.Id);
        scale.Start();
        await _dbContext.SaveChangesAsync();
        return Unit.Value;
    }
}