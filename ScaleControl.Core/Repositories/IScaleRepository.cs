using ScaleControl.Core.Entities;

namespace ScaleControl.Core.Repositories;

public interface IScaleRepository
{
    Task<List<Scale>> GetAll(); 
    Task<Scale> GetScale(int id);
    Task AddAsync(Scale scale);
    Task DeleteScale(Scale scale);
    Task SaveChangesAsync();
}