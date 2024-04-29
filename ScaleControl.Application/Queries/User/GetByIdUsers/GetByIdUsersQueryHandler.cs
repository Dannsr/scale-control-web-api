using MediatR;
using Microsoft.EntityFrameworkCore;
using ScaleControl.Core.Repositories;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Queries.User.GetByIdUsers;

public class GetByIdUsersQueryHandler : IRequestHandler<GetByIdUsersQuery, UserDetailsViewModel>
{
    private readonly IUserRepository _userRepository;

    public GetByIdUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<UserDetailsViewModel> Handle(GetByIdUsersQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUser(request.Enrollment);
        var scales = user.Scales;
        var userDetails = new UserDetailsViewModel(user.Enrollment, user.FullName, user.Email, user.BirthDate,
            user.CreatedAt,
            user.Active, scales);
        return userDetails;
    }
}