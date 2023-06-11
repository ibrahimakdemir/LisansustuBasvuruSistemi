using System;
using System.Collections.Generic;

namespace GraduateAppProject.Infrastructure.Models;

public partial class AlesExam : IEntity
{
    public int Id { get; set; }

    public int CitizenId { get; set; }

    public string DocumentUrl { get; set; } = null!;

    public decimal AlesSayisalGrade { get; set; }

    public decimal AlesEsitAgirlikGrade { get; set; }

    public decimal AlesSozelGrade { get; set; }

    public int Year { get; set; }

    public virtual Citizen Citizen { get; set; } = null!;
}
