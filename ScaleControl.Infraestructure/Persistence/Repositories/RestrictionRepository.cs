using Microsoft.EntityFrameworkCore;
using ScaleControl.Core.Entities;
using ScaleControl.Core.Repositories;

namespace ScaleControl.Infraestructure.Persistence;

public class RestrictionRepository : IRestrictionRepository
{
    private readonly ScaleControlDbContext _dbContext;

    public RestrictionRepository(ScaleControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Restriction>> GetAll()
    {
        return await _dbContext.Restrictions.ToListAsync();
    }

    public async Task<Restriction> GetRestriction(int enrollment)
    {
        return await _dbContext.Restrictions.Include(u => u.User).SingleOrDefaultAsync(r => r.User.Enrollment == enrollment);
    }

    public async Task AddAsync(Restriction restriction)
    {
        await _dbContext.Restrictions.AddAsync(restriction);
    }

    public async Task DeleteRestriction(Restriction restriction)
    {
        _dbContext.Restrictions.Remove(restriction);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}