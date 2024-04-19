using Microsoft.EntityFrameworkCore;
using ScaleControl.Application.inputModels;
using ScaleControl.Application.Services.Interfaces;
using ScaleControl.Application.ViewModels;
using ScaleControl.Infraestructure.Persistence;
using ScaleControl.Core;
using ScaleControl.Core.Entities;

namespace ScaleControl.Application.Services.Implementations;

public class ScaleService : IScaleService
{
    private readonly ScaleControlDbContext _dbContext;

    public ScaleService(ScaleControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<ScaleViewModel> GetAll(string query)
    {
        var scales = _dbContext.Scales;
        var scalesViewModel = scales.Select((s => new ScaleViewModel(s.TypeService, s.StartAt))).ToList();
        return scalesViewModel;
    }

    public ScaleDetailsViewModel GetById(int id)
    {
        var scale = _dbContext.Scales.Include(u => u.Offices).SingleOrDefault(s => s.Id == id);
        
        if (scale == null)
        {
            return null;
        }
        List<string> officeNames = scale.OfficesNames.Select(u => u.FullName).ToList();
        var scaleDetailsViewModel = new ScaleDetailsViewModel(scale.Id, scale.Description, scale.TypeService,
            scale.StartAt, scale.FinishAt, scale.Status, officeNames);
        return scaleDetailsViewModel;
    }

    public int Create(ScaleInputModel inputModel)
    {
        var scale = new Scale(inputModel.Description, inputModel.IdOffices);
        _dbContext.Scales.Add(scale);
        _dbContext.SaveChanges();
        return scale.Id;
    }

    public void Update(ScaleInputModel inputModel)
    {
        var scale = _dbContext.Scales.SingleOrDefault(p => p.Id == inputModel.Id);
    }

    public void Delete(int id)
    {
        var scale = _dbContext.Scales.SingleOrDefault(s => s.Id == id);
        scale.Cancel();
        _dbContext.SaveChanges();
        _dbContext.Scales.Remove(scale);
    }

    public void Start(int id)
    {
        var scale = _dbContext.Scales.SingleOrDefault(s => s.Id == id);
        scale.Start();
        _dbContext.SaveChanges();
    }

    public void Finish(int id)
    {
        var scale = _dbContext.Scales.SingleOrDefault(s => s.Id == id);
        scale.Finish();
        _dbContext.SaveChanges();
    }
}