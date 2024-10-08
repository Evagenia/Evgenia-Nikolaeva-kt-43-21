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
                TeacherId = 1,
                FirstName = "Николаева",
                MiddleName = "Евгения",
                LastName = "Александровна",
                Position = "ст. препод",
                Degree = null,
                CathedraId = 1,
                Cathedra = null
            };

            var result = teacher.HasAcademicDegree();

            Assert.False(result);
        }

        [Fact]
        public void HasDegree_Ktn_True()
        {
            var teacher = new Teacher
            {
                TeacherId = 1,
                FirstName = "Ванеркин",
                MiddleName = "Илья",
                LastName = "Федорович",
                Position = "ст. препод",
                Degree = "к.н.п",
                CathedraId = 1,
                Cathedra = null 
            };

            var result = teacher.HasAcademicDegree();

            Assert.True(result);
        }


    }
    
}