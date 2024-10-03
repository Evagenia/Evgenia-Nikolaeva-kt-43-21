using Nikolaeva_kt_43_21.Database;
using Nikolaeva_kt_43_21.Models;

namespace Nikolaeva_kt_43_21.Filters.TeacherInterfaces
{
    public interface ITeacherModifierService
    {
        public Task CreateTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default);
        public Task EditTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default);
        public Task RemoveTeacherAsync(Teacher teacherId, CancellationToken cancellationToken = default);
    }

    public class TeacherModifierService : ITeacherModifierService
    {
        private readonly TeacherDbContext _dbContext;

        public TeacherModifierService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task CreateTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            bool isTeacherExists = _dbContext.Set<Teacher>().Where(t => t.TeacherId == teacher.TeacherId).Any();
            if (isTeacherExists)
            {
                throw new KeyNotFoundException($"Преподаватель с таким идентификатором уже есть!");
            }

            var entity = _dbContext.Set<Teacher>().Add(teacher);
            var task = _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task EditTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            bool isTeacherExists = _dbContext.Set<Teacher>().Where(t => t.TeacherId == teacher.TeacherId).Any();
            if (!isTeacherExists)
            {
                throw new KeyNotFoundException($"Преподаватель не найден!");
            }

            _dbContext.Set<Teacher>().Update(teacher);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task RemoveTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            bool isTeacherExists = _dbContext.Set<Teacher>().Where(t => t.TeacherId == teacher.TeacherId).Any();
            if (!isTeacherExists)
            {
                throw new KeyNotFoundException($"Преподаватель не найден!");
            }

            _dbContext.Set<Teacher>().Remove(teacher);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
