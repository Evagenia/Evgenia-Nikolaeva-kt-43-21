﻿using System.Text.Json.Serialization;

namespace Nikolaeva_kt_43_21.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }

        public required string Name { get; set; } = string.Empty;

        public int TeacherId { get; set; }

        [JsonIgnore]
        public Teacher? Teacher { get; set; }
    }
}
