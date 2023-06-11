using System;
using System.Collections.Generic;

namespace GraduateAppProject.Infrastructure.Models;

public partial class DoctorateDegree : IEntity
{
    public int Id { get; set; }

    public int CitizenId { get; set; }

    public int GraduateMajorId { get; set; }

    public bool IsActive { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string DiplomaUrl { get; set; } = null!;

    public int LanguageId { get; set; }

    public virtual Citizen Citizen { get; set; } = null!;

    public virtual GraduateMajor GraduateMajor { get; set; } = null!;

    public virtual Language Language { get; set; } = null!;
}
