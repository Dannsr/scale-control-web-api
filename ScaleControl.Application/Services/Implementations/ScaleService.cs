using ScaleControl.Application.inputModels;
using ScaleControl.Application.Services.Interfaces;
using ScaleControl.Application.ViewModels;

namespace ScaleControl.Application.Services.Implementations;

public class ScaleService : IScaleService
{
    public List<ScaleViewModel> GetAll(string query)
    {
        throw new NotImplementedException();
    }

    public ScaleDetailsViewModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public int Create(NewScaleInputModel inputModel)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateProjectInputModel inputModel)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void Start(int id)
    {
        throw new NotImplementedException();
    }

    public void Finish(int id)
    {
        throw new NotImplementedException();
    }
}