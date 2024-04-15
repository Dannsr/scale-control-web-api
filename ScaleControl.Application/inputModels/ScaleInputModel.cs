using ScaleControl.Core.Entities;
using ScaleControl.Core.Enums;

namespace ScaleControl.Application.inputModels;

public class ScaleInputModel
{
    public string Description { get; set; }
    public List<User> IdOffices { get; set; }
    public ScaleStatusEnum Status { get; set; }
    public ScaleTypeServiceEnum TypeService { get; set;}
    public ScaleTurnEnum Turn { get; set; }
    
}