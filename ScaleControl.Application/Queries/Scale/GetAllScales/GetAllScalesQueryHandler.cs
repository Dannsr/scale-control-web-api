using MediatR;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Queries.Scale;

public class GetAllScalesQueryHandler : IRequestHandler<GetAllScalesQuery, List<ScaleViewModel>>
{
    private readonly ScaleControlDbContext _dbContext;

    public GetAllScalesQueryHandler(ScaleControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ScaleViewModel>> Handle(GetAllScalesQuery request, CancellationToken cancellationToken)
    {
        var scales = _dbContext.Scales;
        var scalesViewModel = scales.Select((s => new ScaleViewModel(s.TypeService, s.StartAt))).ToList();
        return scalesViewModel;
    }
}