using System;
using System.Collections.Generic;

namespace GraduateAppProject.Infrastructure.Models;

public partial class Faculty : IEntity
{
    public int Id { get; set; }

    public string FacultyName { get; set; } = null!;

    public int UniversityId { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual University University { get; set; } = null!;
}
