using System;
using System.Collections.Generic;

namespace GraduateAppProject.Infrastructure.Models;

public partial class GraduateMajor : IEntity
{
    public int Id { get; set; }

    public string GraduateMajorName { get; set; } = null!;

    public int InstituteId { get; set; }

    public virtual ICollection<DoctorateDegree> DoctorateDegrees { get; set; } = new List<DoctorateDegree>();

    public virtual Institute Institute { get; set; } = null!;
}
