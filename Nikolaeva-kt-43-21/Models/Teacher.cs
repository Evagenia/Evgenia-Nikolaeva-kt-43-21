namespace Nikolaeva_kt_43_21.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public int CathedraId { get; set; }

        public required Cathedra Cathedra { get; set; }
    }
}
