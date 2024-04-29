using MediatR;

namespace ScaleControl.Application.Queries.User.GetAllUsers;

public class GetAllUsersQuery : IRequest<UserViewModel>, IRequest<List<UserViewModel>>
{
    public GetAllUsersQuery(string query)
    {
        Query = query;
    }

    public string Query { get; private set; }
    
    
}

public class UserViewModel
{
    public UserViewModel(int enrollment, string fullName, List<Core.Entities.Scale?> lastScale)
    {
        Enrollment = enrollment;
        FullName = fullName;
        LastScale = lastScale;
    }
    public int Enrollment { get; private set; }
    public string FullName { get; private set; }
    public List<Core.Entities.Scale?> LastScale { get; private set; }
    
}