using System.Net.Sockets;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Nikolaeva_kt_43_21.Models
{
    public class Teacher
    {
        [JsonIgnore]
        public int TeacherId { get; set; }

        public required string FirstName { get; set; } = string.Empty;

        public required string LastName { get; set; } = string.Empty;

        public required string MiddleName { get; set; } = string.Empty;
         public required string Position {  get; set; } 

        public string? Degree { get; set; } 

        public int CathedraId { get; set; }

        [JsonIgnore]
        public Cathedra? Cathedra { get; set; }

        public bool HasAcademicDegree() => Degree != null;
    }
}
