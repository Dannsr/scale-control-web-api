using Microsoft.EntityFrameworkCore;
using ScaleControl.Core.Entities;
using ScaleControl.Core.Repositories;

namespace ScaleControl.Infraestructure.Persistence;

public class ScaleRepository : IScaleRepository
{
    private readonly ScaleControlDbContext _dbContext;

    public ScaleRepository(ScaleControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Scale>> GetAll()
    {
        return await _dbContext.Scales.ToListAsync();
    }

    public async Task<Scale> GetScale(int id)
    {
        return await _dbContext.Scales.Include(u => u.Users).SingleOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Scale scale)
    {
        await _dbContext.Scales.AddAsync(scale);
    }

    public async Task DeleteScale(Scale scale)
    {
        _dbContext.Scales.Remove(scale);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}