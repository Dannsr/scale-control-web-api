using ScaleControl.Core.Entities;

namespace ScaleControl.Application.inputModels;

public class CreateUserInputModel 
{
    public string FullName { get; set; }
    public int Enrollment { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
}