using System.Runtime.InteropServices.JavaScript;
using ScaleControl.Core.Enums;

namespace ScaleControl.Application.ViewModels;

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