using ScaleControl.Core.Entities;

namespace ScaleControl.Application.ViewModels;

public class UserDetailsViewModel
{
    public UserDetailsViewModel(int enrollment, string fullName, string email, DateTime birthDate, DateTime createdAt, bool active, List<UserScale?> scales)
    {
        Enrollment = enrollment;
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        CreatedAt = createdAt;
        Active = active;
        Scales = scales;
    }

    public int Enrollment { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool Active { get; private set; }
    public List<UserScale?> Scales { get; private set; }
}