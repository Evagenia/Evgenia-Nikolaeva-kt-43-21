using Nikolaeva_kt_43_21.Models;

namespace Nikolaeva_kt_43_21.Tests
{
    public class TeacherTests
    {
        [Fact]
        public void HasDegree_Null_False()
        {
            var teacher = new Teacher
            {
                Degree = null,
            };

            var result = teacher.HasDegree();

            Assert.False(result);
        }

        [Fact]
        public void HasDegree_Ktn_True()
        {
            var teacher = new Teacher
            {
                Degree = "к.п.н.",
            };

            var result = teacher.HasDegree();

            Assert.True(result);
        }

        [Fact]
        public void IsValidPotition_zavkaf_False()
        {
            var teacher = new Teacher
            {
                Position = "зав. каф."
            };

            var result = teacher.IsValidPosition();

            Assert.False(result);
        }

        [Fact]
        public void IsValidPotition_Zavkaf_True()
        {
            var teacher = new Teacher
            {
                Position = "Зав. каф."
            };

            var result = teacher.IsValidPosition();

            Assert.True(result);
        }


    }
    
}