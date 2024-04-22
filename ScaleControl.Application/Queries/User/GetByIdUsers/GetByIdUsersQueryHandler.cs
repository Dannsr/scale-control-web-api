using MediatR;
using Microsoft.EntityFrameworkCore;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Queries.User.GetByIdUsers;

public class GetByIdUsersQueryHandler : IRequestHandler<GetByIdUsersQuery, UserDetailsViewModel>
{
    private readonly ScaleControlDbContext _dbContext;
    public GetByIdUsersQueryHandler(ScaleControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<UserDetailsViewModel> Handle(GetByIdUsersQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Enrollment == request.Enrollment);
        var userDetails = new UserDetailsViewModel(user.Enrollment, user.FullName, user.Email, user.BirthDate,
            user.CreatedAt,
            user.Active, user.Scales);
        return userDetails;
    }
}