using MediatR;
using Microsoft.EntityFrameworkCore;
using ScaleControl.Application.Queries.Scale;
using ScaleControl.Core.Repositories;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Queries.User.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
{
    private readonly IUserRepository _userRepository;
    
    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAll();
        var scales = users.Select(u => u.Scales).ToList();
        var usersViewModel = users
            .Select(u => new UserViewModel(u.Enrollment, u.FullName, scales))
            .ToList();
        return usersViewModel;
    }
}