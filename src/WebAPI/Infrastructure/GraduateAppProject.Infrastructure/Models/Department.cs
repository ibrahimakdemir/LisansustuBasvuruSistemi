using System;
using System.Collections.Generic;

namespace GraduateAppProject.Infrastructure.Models;

public partial class Department : IEntity
{
    public int Id { get; set; }

    public int UniversityId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public int FacultyId { get; set; }

    public virtual ICollection<BachelorDegree> BachelorDegrees { get; set; } = new List<BachelorDegree>();

    public virtual Faculty Faculty { get; set; } = null!;

    public virtual ICollection<MasterDegree> MasterDegrees { get; set; } = new List<MasterDegree>();

    public virtual University University { get; set; } = null!;
}
