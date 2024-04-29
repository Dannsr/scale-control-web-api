using MediatR;
using ScaleControl.Application.Commands.User;
using ScaleControl.Core.Repositories;

namespace ScaleControl.Application.Commands.CreateScale;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _userRepository;
    
    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    { 
        var user = new Core.Entities.User(request.Enrollment, request.FullName, request.Email, request.BirthDate, request.Almanac, request.Graduation, request.Chart);
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();
        return user.Id;
    }
}
