using ScaleControl.Core.Entities;

namespace ScaleControl.Infraestructure.Persistence;

public class ScaleControlDbContext
{
    public ScaleControlDbContext()
    {
        List<User> scaleUsers = new List<User>
        {
            new User("João Silva", "joao@example.com", new DateTime(1990, 5, 15)),
            new User("Maria Souza", "maria@example.com", new DateTime(1985, 9, 20))
        };
        Users = new List<User>
        {
            new User("Rodrigo Silva", "rodrigo@example.com", new DateTime(1990, 2, 23)),
            new User("Daniel Silva", "daniel@example.com", new DateTime(2004, 10, 04)),
        };
        Users.AddRange(scaleUsers);
        Scales = new List<Scale>
        {
            new Scale("Operacional", scaleUsers)
        };
    }
    public List<Scale> Scales { get; set; }
    public List<User> Users { get; set; }
}