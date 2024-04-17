using ScaleControl.Application.inputModels;
using ScaleControl.Application.Services.Interfaces;
using ScaleControl.Application.ViewModels;
using ScaleControl.Core.Entities;
using ScaleControl.Infraestructure.Persistence;

namespace ScaleControl.Application.Services.Implementations;

public class UserService : IUserService
{
    private readonly ScaleControlDbContext _dbContext;

    public UserService(ScaleControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    List<UserViewModel> IUserService.GetAll()
    {
        var users = _dbContext.Users;
        var usersViewModel = users.Select(u => new UserViewModel(u.Enrollment, u.FullName, u.Scales.FirstOrDefault())).ToList();
        return usersViewModel;
    }

    public UserDetailsViewModel GetById(int enrollment)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Enrollment == enrollment);
        var userDetails = new UserDetailsViewModel(user.Enrollment, user.FullName, user.Email, user.BirthDate, user.CreatedAt,
            user.Active, user.Scales);
        return userDetails;
    }

    public int Create(CreateUserInputModel inputModel)
    {
        var user = new User(inputModel.Enrollment, inputModel.FullName, inputModel.Email, inputModel.BirthDate);
        _dbContext.Users.Add(user);
        return user.Id;
    }
}