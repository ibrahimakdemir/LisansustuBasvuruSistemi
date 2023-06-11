namespace GraduateAppProject.Entities
{
    public class Language : IEntity
    {
        public int Id { get; set; }

        public string LanguageName { get; set; } = null!;

        public ICollection<GraduateProgram> GraduatePrograms { get; set; } = new HashSet<GraduateProgram>();
    }
}