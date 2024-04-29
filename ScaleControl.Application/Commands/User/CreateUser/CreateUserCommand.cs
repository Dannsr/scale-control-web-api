using MediatR;
using ScaleControl.Core.Enums;

namespace ScaleControl.Application.Commands.User;

public class CreateUserCommand : IRequest<int>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public int Enrollment { get; set; }
    public int Almanac { get; set; }
    public RankEnum Graduation { get; set; }
    public ChartEnum Chart { get; set; }
}