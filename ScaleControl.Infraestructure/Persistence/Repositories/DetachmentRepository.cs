using Microsoft.EntityFrameworkCore;
using ScaleControl.Core.Entities;
using ScaleControl.Core.Repositories;

namespace ScaleControl.Infraestructure.Persistence;

public class DetachmentRepository : IDetachmentRepository
{
    private readonly ScaleControlDbContext _dbContext;

    public DetachmentRepository(ScaleControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Detachment>> GetAll()
    {
        return await _dbContext.Detachments.ToListAsync();
    }

    public async Task<Detachment> GetDetachment(int enrollment)
    {
        return await _dbContext.Detachments.Include(u => u.User).SingleOrDefaultAsync(s => s.User.Enrollment == enrollment);
    }

    public async Task AddAsync(Detachment detachment)
    {
        await _dbContext.Detachments.AddAsync(detachment);
    }

    public async Task DeleteDetachment(Detachment detachment)
    {
        _dbContext.Detachments.Remove(detachment);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}