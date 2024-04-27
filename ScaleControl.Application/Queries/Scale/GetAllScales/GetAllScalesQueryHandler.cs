using MediatR;
using ScaleControl.Core.Repositories;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Queries.Scale;

public class GetAllScalesQueryHandler : IRequestHandler<GetAllScalesQuery, List<ScaleViewModel>>
{
    private readonly IScaleRepository _scaleRepository;
    
    public GetAllScalesQueryHandler(IScaleRepository scaleRepository)
    {
        _scaleRepository = scaleRepository;
    }

    public async Task<List<ScaleViewModel>> Handle(GetAllScalesQuery request, CancellationToken cancellationToken)
    {
        var scales = await _scaleRepository.GetAll();
        var scalesViewModel = scales.Select((s => new ScaleViewModel(s.TypeService, s.StartAt))).ToList();
        return scalesViewModel;
    }
}