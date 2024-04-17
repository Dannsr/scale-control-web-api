namespace ScaleControl.Core.Entities;

public class UserScale : BaseEntity
{
    public UserScale(int idUser, int idScale)
    {
        IdUser = idUser;
        IdScale = idScale;
    }

    public int IdUser { get; private set; }
    public int IdScale { get; private set; }
}