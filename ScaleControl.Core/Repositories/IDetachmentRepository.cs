
using ScaleControl.Core.Entities;

namespace ScaleControl.Core.Repositories;

public interface IDetachmentRepository
{
    Task<List<Detachment>> GetAll();
    Task<Detachment> GetDetachment(int enrollment);
    Task AddAsync(Detachment detachment);
    
    Task DeleteDetachment(Detachment detachment);
    Task SaveChangesAsync();
}