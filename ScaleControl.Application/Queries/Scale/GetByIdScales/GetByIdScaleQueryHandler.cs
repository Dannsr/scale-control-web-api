using MediatR;
using Microsoft.EntityFrameworkCore;
using ScaleControl.Core.Repositories;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Queries.Scale.GetByIdScales;

public class GetByIdScaleQueryHandler : IRequestHandler<GetByIdScaleQuery, ScaleDetailsViewModel>
{
    private readonly IScaleRepository _scaleRepository;

    public GetByIdScaleQueryHandler(IScaleRepository scaleRepository)
    {
        _scaleRepository = scaleRepository;
    }


    public async Task<ScaleDetailsViewModel> Handle(GetByIdScaleQuery request, CancellationToken cancellationToken)
    {
        var scale = await _scaleRepository.GetScale(request.Id);
        
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