using System;
using System.Collections.Generic;

namespace GraduateAppProject.Infrastructure.Models;

public partial class Citizen : IEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FatherName { get; set; } = null!;

    public string MotherName { get; set; } = null!;

    public string CitizenNumber { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string BirthPlace { get; set; } = null!;

    public virtual ICollection<AlesExam> AlesExams { get; set; } = new List<AlesExam>();

    public virtual ICollection<BachelorDegree> BachelorDegrees { get; set; } = new List<BachelorDegree>();

    public virtual ICollection<DoctorateDegree> DoctorateDegrees { get; set; } = new List<DoctorateDegree>();

    public virtual ICollection<MasterDegree> MasterDegrees { get; set; } = new List<MasterDegree>();

    public virtual ICollection<YdsExam> YdsExams { get; set; } = new List<YdsExam>();
}
