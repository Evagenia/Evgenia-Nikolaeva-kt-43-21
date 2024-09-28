using Microsoft.EntityFrameworkCore;
using Nikolaeva_kt_43_21.Database;
using Nikolaeva_kt_43_21.Filters.TeacherInterfaces;
using Nikolaeva_kt_43_21.Models;

namespace Nikolaeva_kt_43_21.Interfaces.TeacherInterfaces
{
    public interface ITeacherService
    {
        public Task<Teacher[]> GetTeachersByCathedraAsync(TeacherCathedraFilter filter, CancellationToken cancellationToken);
    }

    public class TeacherService : ITeacherService
    {
        private readonly TeacherDbContext _dbContext;

        public TeacherService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Teacher[]> GetTeachersByCathedraAsync(TeacherCathedraFilter filter, CancellationToken cancellationToken)
        {
            var teachers = _dbContext.Set<Teacher>().Where(t => t.Cathedra.Name == filter.CathedraName).ToArrayAsync();
            return teachers;
        }
    }
}
