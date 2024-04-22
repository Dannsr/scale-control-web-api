using MediatR;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Commands.UpdateScale;

public class UpdateScaleCommandHandler : IRequestHandler<UpdateScaleCommand, Unit>
{
    private readonly ScaleControlDbContext _dbContext;

    public UpdateScaleCommandHandler(ScaleControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Unit> Handle(UpdateScaleCommand request, CancellationToken cancellationToken)
    {
        var scale = _dbContext.Scales.SingleOrDefault(s => s.Id == request.Id);
        scale.Update(request.IdOffices, request.Status, request.TypeService, request.Turn, request.FinishAt,
            request.FinishAt);
        await _dbContext.SaveChangesAsync();
        return Unit.Value;
    }
}
