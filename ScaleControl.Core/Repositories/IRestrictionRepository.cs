using ScaleControl.Core.Entities;

namespace ScaleControl.Core.Repositories;

public interface IRestrictionRepository
{
    Task<List<Restriction>> GetAll();
    Task<Restriction> GetRestriction(int enrollment);
    Task AddAsync(Restriction restriction);
    Task DeleteRestriction(Restriction restriction);
    Task SaveChangesAsync();
}