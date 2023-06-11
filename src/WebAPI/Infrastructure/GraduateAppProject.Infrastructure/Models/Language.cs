using System;
using System.Collections.Generic;

namespace GraduateAppProject.Infrastructure.Models;

public partial class Language : IEntity
{
    public int Id { get; set; }

    public string Language1 { get; set; } = null!;

    public virtual ICollection<BachelorDegree> BachelorDegrees { get; set; } = new List<BachelorDegree>();

    public virtual ICollection<DoctorateDegree> DoctorateDegrees { get; set; } = new List<DoctorateDegree>();

    public virtual ICollection<MasterDegree> MasterDegrees { get; set; } = new List<MasterDegree>();
}
