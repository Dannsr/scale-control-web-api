using System.Runtime.InteropServices.JavaScript;
using ScaleControl.Core.Enums;

namespace ScaleControl.Application.ViewModels;

public class ScaleDetailsViewModel
{
    public ScaleDetailsViewModel(int id, string description, ScaleTypeServiceEnum typeServiceEnum, DateTime startAt, DateTime finishAt, ScaleStatusEnum status, IEnumerable<int> idOffices)
    {
        Id = id;
        Description = description;
        TypeServiceEnum = typeServiceEnum;
        StartAt = startAt;
        FinishAt = finishAt;
        Status = status;
        IdOffices = idOffices;
    }

    public int Id { get; set; }
    public string Description { get; set; }
    public ScaleTypeServiceEnum TypeServiceEnum { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime FinishAt { get; set; }
    public ScaleStatusEnum Status { get; set; }
    public IEnumerable<int> IdOffices { get; set; }
    
}