using ScaleControl.Application.inputModels;
using ScaleControl.Application.ViewModels;

namespace ScaleControl.Application.Services.Interfaces;

public interface IUserService
{
    List<UserViewModel> GetAll();
    UserDetailsViewModel GetById(int id);
    int Create(CreateUserInputModel inputModel);
}