using MediatR;
using Microsoft.EntityFrameworkCore;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Queries.Scale.GetByIdScales;

public class GetByIdScaleQueryHandler : IRequestHandler<GetByIdScaleQuery, ScaleDetailsViewModel>
{
    private readonly ScaleControlDbContext _dbContext;

    public GetByIdScaleQueryHandler(ScaleControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<ScaleDetailsViewModel> Handle(GetByIdScaleQuery request, CancellationToken cancellationToken)
    {
        var scale = _dbContext.Scales.Include(u => u.Offices).SingleOrDefault(s => s.Id == request.Id);
        
        if (scale == null)
        {
            return null;
        }
        List<string> officeNames = scale.OfficesNames.Select(u => u.FullName).ToList();
        var scaleDetailsViewModel = new ScaleDetailsViewModel(scale.Id,scale.TypeService,
            scale.StartAt, scale.FinishAt, scale.Status, officeNames);
        return scaleDetailsViewModel;
    }
}