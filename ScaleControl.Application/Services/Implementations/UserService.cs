using ScaleControl.Application.inputModels;
using ScaleControl.Application.Services.Interfaces;
using ScaleControl.Application.ViewModels;
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
        throw new NotImplementedException(); 
    }

    public UserDetailsViewModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public int Create(CreateUserInputModel inputModel)
    {
        throw new NotImplementedException();
    }
}