using MediatR;
using Microsoft.EntityFrameworkCore;
using ScaleControl.Application.Queries.Scale;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Queries.User.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
{
    private readonly ScaleControlDbContext _dbContext;
    public GetAllUsersQueryHandler(ScaleControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = _dbContext.Users;
        var usersViewModel = await users
            .Select(u => new UserViewModel(u.Enrollment, u.FullName, u.Scales))
            .ToListAsync();
        return usersViewModel;
    }
}