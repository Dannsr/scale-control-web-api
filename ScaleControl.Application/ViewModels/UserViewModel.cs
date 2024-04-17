using ScaleControl.Core.Entities;

namespace ScaleControl.Application.ViewModels;

public class UserViewModel
{
    public UserViewModel(int enrollment, string fullName, UserScale? lastScale)
    {
        Enrollment = enrollment;
        FullName = fullName;
        LastScale = lastScale;
    }
    public int Enrollment { get; private set; }
    public string FullName { get; private set; }
    public UserScale? LastScale { get; private set; }
    
}