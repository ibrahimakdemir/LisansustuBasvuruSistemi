using System;
using System.Collections.Generic;

namespace GraduateAppProject.Infrastructure.Models;

public partial class Institute : IEntity
{
    public int Id { get; set; }

    public string InstituteName { get; set; } = null!;

    public virtual ICollection<GraduateMajor> GraduateMajors { get; set; } = new List<GraduateMajor>();
}
