using Microsoft.EntityFrameworkCore;
using Nikolaeva_kt_43_21.Database;
using Nikolaeva_kt_43_21.Filters;
using Nikolaeva_kt_43_21.Interfaces.TeacherInterfaces;
using Nikolaeva_kt_43_21.Models;

namespace Nikolaeva_kt_43_21.Tests
{
    public class TeacherIntegrationTests
    {
        public readonly DbContextOptions<TeacherDbContext> _dbContextOptions;

        public TeacherIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<TeacherDbContext>()
                .UseInMemoryDatabase("pp_student_db_test")
                .Options;

            ArrangeData();
        }

        private void ArrangeData()
        {
            // Arrange
            using var ctx = new TeacherDbContext(_dbContextOptions);
            var cathedras = new List<Cathedra>
            {
                new Cathedra
                {
                    CathedraId = 1,
                    Name = "Cathedra1",
                },
                new Cathedra
                {
                    CathedraId = 2,
                    Name = "Cathedra2",
                }
            };
            ctx.Set<Cathedra>().AddRange(cathedras);

            var teachers = new List<Teacher>
            {
                new Teacher
                {
                    FirstName = "first1",
                    LastName = "first1",
                    MiddleName = "first1",
                    Position = "first1",
                    CathedraId = 1
                },
                new Teacher
                {
                    FirstName = "second",
                    LastName = "second",
                    MiddleName = "second",
                    Position = "second",
                    CathedraId = 2,
                },
                new Teacher
                {
                    FirstName = "first2",
                    LastName = "first2",
                    MiddleName = "first2",
                    Position = "first2",
                    CathedraId = 1,
                }
            };
            ctx.Set<Teacher>().AddRange(teachers);
            ctx.SaveChanges();
        }

        [Fact]
        public async Task GetTeachersByCathedraAsync_Cathedra1_TwoObjects()
        {
            // Arrange
            using var ctx = new TeacherDbContext(_dbContextOptions);
            var teacherGetterService = new TeacherGetterService(ctx);

            // Act
            var filter = new TeacherCathedraFilter()
            {
                CathedraName = "Cathedra1"
            };

            var teachersResult = await teacherGetterService.GetTeachersByCathedraAsync(filter);

            // Assert
            Assert.Equal(2, teachersResult.Length);
        }
    }
}
