using Microsoft.EntityFrameworkCore;
using Nikolaeva_kt_43_21.Database;
using Nikolaeva_kt_43_21.Filters.TeacherInterfaces;
using Nikolaeva_kt_43_21.Models;

namespace Nikolaeva_kt_43_21.Interfaces.TeacherInterfaces
{
    public interface ITeacherGetterService
    {
        public Task<Teacher[]> GetTeachersByDegreeAsync(TeacherDegreeFilter filter, CancellationToken cancellationToken);
        
        public Task<Teacher[]> GetTeachersByCathedraAsync(TeacherCathedraFilter filter, CancellationToken cancellationToken);

        public Task<Teacher[]> GetTeachersByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken);
    }

    public class TeacherGetterService : ITeacherGetterService
    {
        private readonly TeacherDbContext _dbContext;

        public TeacherGetterService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Teacher[]> GetTeachersByDegreeAsync(TeacherDegreeFilter filter, CancellationToken cancellationToken)
        {
            var teachers = _dbContext.Set<Teacher>().Where(t => t.Degree == filter.Degree).ToArrayAsync();
            return teachers;
        }

        public Task<Teacher[]> GetTeachersByCathedraAsync(TeacherCathedraFilter filter, CancellationToken cancellationToken)
        {
            var teachers = _dbContext.Set<Teacher>().Where(t => t.Cathedra.Name == filter.CathedraName).ToArrayAsync();
            return teachers;
        }

        public Task<Teacher[]> GetTeachersByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken)
        {
            var teachers = _dbContext.Set<Teacher>().Where(t => t.Position == filter.Position).ToArrayAsync();
            return teachers;
        }
    }
}
