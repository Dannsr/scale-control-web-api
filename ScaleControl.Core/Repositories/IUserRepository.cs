using ScaleControl.Core.Entities;
namespace ScaleControl.Core.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User> GetUser(int enrollment);
    
    Task AddAsync(User user);
    Task SaveChangesAsync();
}