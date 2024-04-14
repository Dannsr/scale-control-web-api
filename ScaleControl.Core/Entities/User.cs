using System.Runtime.InteropServices.JavaScript;

namespace ScaleControl.Core.Entities;

public class User : BaseEntity
{
    public User(string fullName, string email, DateTime birthDate)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        CreatedAt = DateTime.Now;
        Active = true;
        Scales = new List<UserScale>();
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public bool Active { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public List<UserScale> Scales { get; private set; }
}