using MediatR;
using ScaleControl.Application.Commands.User;
using ScaleControl.Core.Entities;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Commands.CreateScale;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly ScaleControlDbContext _dbContext;

    public CreateUserCommandHandler(ScaleControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    { 
        var user = new Core.Entities.User(request.Enrollment, request.FullName, request.Email, request.BirthDate);
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user.Id;
    }
}
