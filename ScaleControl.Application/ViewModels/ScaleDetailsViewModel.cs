using System.Runtime.InteropServices.JavaScript;
using ScaleControl.Core.Entities;
using ScaleControl.Core.Enums;

namespace ScaleControl.Application.ViewModels;

public class ScaleDetailsViewModel
{
    public ScaleDetailsViewModel(int id, string description, ScaleTypeServiceEnum typeServiceEnum, DateTime startAt, DateTime finishAt, ScaleStatusEnum status, List<string> officesFullNames)
    {
        Id = id;
        Description = description;
        TypeServiceEnum = typeServiceEnum;
        StartAt = startAt;
        FinishAt = finishAt;
        Status = status;
        OfficesFullNames = officesFullNames;
    }

    public int Id { get; private set; }
    public string Description { get; private set; }
    public ScaleTypeServiceEnum TypeServiceEnum { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime FinishAt { get; private set; }
    public ScaleStatusEnum Status { get; private set; }
    public List<string> OfficesFullNames { get; private set; }
    
    
    
}