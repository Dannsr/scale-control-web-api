using Microsoft.EntityFrameworkCore;
using ScaleControl.Core.Entities;
using ScaleControl.Core.Repositories;

namespace ScaleControl.Infraestructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly ScaleControlDbContext _dbContext;
    public UserRepository(ScaleControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<User>> GetAll()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User> GetUser(int enrollment)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(u => u.Enrollment == enrollment);
    }
    
    public async Task AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    
    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}