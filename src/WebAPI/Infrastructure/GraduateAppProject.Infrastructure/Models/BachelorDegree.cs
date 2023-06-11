using System;
using System.Collections.Generic;

namespace GraduateAppProject.Infrastructure.Models;

public partial class BachelorDegree : IEntity
{
    public int Id { get; set; }

    public int CitizenId { get; set; }

    public int DepartmentId { get; set; }

    public bool IsActive { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int GradeType { get; set; }

    public decimal DegreeGrade { get; set; }

    public bool WithThesis { get; set; }

    public int LanguageId { get; set; }

    public string DiplomaUrl { get; set; } = null!;

    public string? TranscriptUrl { get; set; }

    public virtual Citizen Citizen { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual Language Language { get; set; } = null!;
}
