using MediatR;
using ScaleControl.Core.Entities;

namespace ScaleControl.Application.Queries.User.GetAllUsers;

public class GetAllUsersQuery : IRequest<UserViewModel>, IRequest<List<UserViewModel>>
{
    public GetAllUsersQuery(string query)
    {
        this.query = query;
    }

    public string query { get; private set; }
    
    
}

public class UserViewModel
{
    public UserViewModel(int enrollment, string fullName, List<UserScale> lastScale)
    {
        Enrollment = enrollment;
        FullName = fullName;
        LastScale = lastScale;
    }
    public int Enrollment { get; private set; }
    public string FullName { get; private set; }
    public List<UserScale> LastScale { get; private set; }
    
}