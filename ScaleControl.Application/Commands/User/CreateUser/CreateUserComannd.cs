using MediatR;
using ScaleControl.Core.Entities;

namespace ScaleControl.Application.Commands.User;

public class CreateUserCommand : IRequest<int>
{
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public bool Active { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public List<UserScale> Scales { get; private set; }
    public int Enrollment { get; set; }
}