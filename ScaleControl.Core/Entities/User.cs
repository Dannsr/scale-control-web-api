using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;
using ScaleControl.Core.Base;
using ScaleControl.Core.Enums;

namespace ScaleControl.Core.Entities;

public class User : BaseEntity
{
    public User(int enrollment, string fullName, string email, DateTime birthDate, int almanac)
    {
        Almanac = almanac;
        Enrollment = enrollment;
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        CreatedAt = DateTime.Now;
        Active = true;
    }
    public User(int enrollment, string fullName, string email, DateTime birthDate, int almanac, RankEnum graduation, ChartEnum chart)
    {
        Graduation = graduation;
        Almanac = almanac;
        Enrollment = enrollment;
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        CreatedAt = DateTime.Now;
        Active = true;
        Chart = chart;
    }
    public RankEnum Graduation { get; private set; }
    public int Almanac { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public bool Active { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public int Enrollment { get; set; }
    
    public ChartEnum Chart { get; private set; }
    
    
    
    public int? IdScale { get; private set; }
    [ForeignKey("IdScale")]
    public Scale? Scales { get; private set; }
    
    public int? IdDetachment { get; private set; }
    [ForeignKey("IdDetachment")]
    public Detachment? Detachment { get; private set; }
    
    public int? IdRestriction { get; private set; }
    [ForeignKey("IdRestriction")]
    public Restriction? Restriction { get; private set; }
}