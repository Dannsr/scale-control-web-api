using MediatR;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Commands.Scale.FinishScale;

public class FinishScaleCommandHandler : IRequestHandler<FinishScaleCommand, Unit>
{
    private readonly ScaleControlDbContext _dbContext;

    public FinishScaleCommandHandler(ScaleControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(FinishScaleCommand request, CancellationToken cancellationToken)
    {
        var scale = _dbContext.Scales.SingleOrDefault(s => s.Id == request.Id);
        scale.Finish();
        await _dbContext.SaveChangesAsync();
        return Unit.Value;
    }
}