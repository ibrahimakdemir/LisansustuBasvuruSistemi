using System;
using System.Collections.Generic;

namespace GraduateAppProject.Infrastructure.Models;

public partial class YdsExam : IEntity
{
    public int Id { get; set; }

    public int CitizenId { get; set; }

    public string DocumentUrl { get; set; } = null!;

    public decimal YdsGrade { get; set; }

    public int Year { get; set; }

    public virtual Citizen Citizen { get; set; } = null!;
}
