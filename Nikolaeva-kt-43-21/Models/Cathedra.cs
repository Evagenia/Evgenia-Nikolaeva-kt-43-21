﻿using System.Text.Json.Serialization;

namespace Nikolaeva_kt_43_21.Models
{
    public class Cathedra
    {
        public int CathedraId { get; set; }

        public required string Name { get; set; }

         public int? HeadTeacherId { get; set; }

        [JsonIgnore]
        public  Teacher? HeadTeacher { get; set; }
    }
}
