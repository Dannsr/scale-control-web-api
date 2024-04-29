using MediatR;
using ScaleControl.Core.Entities;

namespace ScaleControl.Application.Queries.User.GetByIdUsers;

public class GetByIdUsersQuery : IRequest<UserDetailsViewModel>
{
    public GetByIdUsersQuery(int enrollment)
    {
        Enrollment = enrollment;
    }

    public int Enrollment { get; private set; }
}

public class UserDetailsViewModel
{
    public UserDetailsViewModel(int enrollment, string fullName, string email, DateTime birthDate, DateTime createdAt, bool active, Core.Entities.Scale? scales)
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
    public Core.Entities.Scale? Scales { get; private set; }
}