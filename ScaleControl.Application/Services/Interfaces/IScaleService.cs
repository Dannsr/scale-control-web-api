using ScaleControl.Application.inputModels;
using ScaleControl.Application.ViewModels;

namespace ScaleControl.Application.Services.Interfaces;

public interface IScaleService
{
    List<ScaleViewModel> GetAll(string query);
    ScaleDetailsViewModel GetById(int id);
    int Create(NewScaleInputModel inputModel);
    void Update(UpdateProjectInputModel inputModel);
    void Delete(int id);
    void Start(int id);
    void Finish(int id);
}