namespace ScaleControl.API.Models;

public class CreateUserModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Enrollment { get; set; }
    public int Sei { get; set; }
}