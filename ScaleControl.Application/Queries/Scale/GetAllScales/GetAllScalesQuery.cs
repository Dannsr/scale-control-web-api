using MediatR;
using ScaleControl.Core.Enums;

namespace ScaleControl.Application.Queries.Scale;

public class GetAllScalesQuery : IRequest<List<ScaleViewModel>>
{
    public GetAllScalesQuery(string query)
    {
        Query = query;
    }

    public string Query { get; private set; }
}

public class ScaleViewModel
{
    public ScaleViewModel(ScaleTypeServiceEnum typeServiceEnum, DateTime startAt)
    {
        TypeServiceEnum = typeServiceEnum;
        StartAt = startAt;
    }

    public ScaleTypeServiceEnum TypeServiceEnum { get; set; }
    public DateTime StartAt { get; set; }
}