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
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var cathedras = new List<Cathedra>
            {
                new Cathedra
                {
                    CathedraId = 1,
                    Name = "Кафедра 1",
                },
                new Cathedra
                {
                    CathedraId = 2,
                    Name = "Кафедра 2",
                }
            };
            ctx.Set<Cathedra>().AddRange(cathedras);

            var teachers = new List<Teacher>
            {
                new Teacher
                {
                    FirstName = "1",
                    LastName = "1",
                    MiddleName = "1",
                    Position = "1",
                    Degree = "Степень",
                    CathedraId = 1
                },
                new Teacher
                {
                    FirstName = "2",
                    LastName = "2",
                    MiddleName = "2",
                    Position = "2",
                    Degree = "Степень",
                    CathedraId = 2,
                },
                new Teacher
                {
                    FirstName = "3",
                    LastName = "3",
                    MiddleName = "3",
                    Position = "3",
                    CathedraId = 1,
                }
            };
            ctx.Set<Teacher>().AddRange(teachers);
            ctx.SaveChanges();
        }

        [Fact]
        public async Task GetTeachersByCathedraAsync_Kafedra1_TwoObjects()
        {
            // Arrange
            using var ctx = new TeacherDbContext(_dbContextOptions);
            var teacherGetterService = new TeacherGetterService(ctx);

            // Act
            var filter = new TeacherCathedraFilter()
            {
                CathedraName = "Кафедра 1"
            };

            var teachersResult = await teacherGetterService.GetTeachersByCathedraAsync(filter);

            // Assert
            Assert.Equal(2, teachersResult.Length);
        }

        [Fact]
        public async Task GetTeachersByDegreeAsync_Stepen_TwoObjects()
        {
            // Arrange
            using var ctx = new TeacherDbContext(_dbContextOptions);
            var teacherGetterService = new TeacherGetterService(ctx);

            // Act
            var filter = new TeacherDegreeFilter()
            {
                Degree = "Степень"
            };

            var teachersResult = await teacherGetterService.GetTeachersByDegreeAsync(filter);

            // Assert
            Assert.Equal(2, teachersResult.Length);
        }

        [Fact]
        public async Task GetTeachersByFIOAsync_Cathedra1_OneObject()
        {
            // Arrange
            using var ctx = new TeacherDbContext(_dbContextOptions);
            var teacherGetterService = new TeacherGetterService(ctx);

            // Act
            var filter = new TeacherFIOFilter()
            {
                FirstName = "1",
                LastName = "1",
                MiddleName = "1"
            };

            var teachersResult = await teacherGetterService.GetTeachersByFIOAsync(filter);

            // Assert
            Assert.Equal(1, teachersResult.Length);
        }
    }
}
