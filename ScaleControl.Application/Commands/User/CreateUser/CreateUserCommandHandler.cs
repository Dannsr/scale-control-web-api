using MediatR;
using Microsoft.Identity.Client;
using ScaleControl.Application.Commands.User;
using ScaleControl.Core.Entities;
using ScaleControl.Core.Repositories;
using ScaleControl.Infraestructure.Persistence;

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
        var user = new Core.Entities.User(request.Enrollment, request.FullName, request.Email, request.BirthDate);
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();
        return user.Id;
    }
}
