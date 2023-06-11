using System;
using System.Collections.Generic;

namespace GraduateAppProject.Infrastructure.Models;

public partial class University : IEntity
{
    public int Id { get; set; }

    public string UniversityName { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();
}
