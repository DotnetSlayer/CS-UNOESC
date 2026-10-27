using EF_Teste.Data;
using EF_Teste.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Teste.Repository
{
    public class StudentCoursesRepository : IStudentCoursesRepository
    {
        private readonly SchoolContext _schoolContext;

        public StudentCoursesRepository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public async Task Create(StudentCourses studentCourses)
        {
            await _schoolContext.StudentCourses.AddAsync(studentCourses);
            await _schoolContext.SaveChangesAsync();
        }

        public async Task Delete(StudentCourses studentCourses)
        {
            _schoolContext.Remove(studentCourses);
            await _schoolContext.SaveChangesAsync();
        }

        public async Task<StudentCourses> Get(int studentId, int courseId)
        {
            return await _schoolContext.StudentCourses
                        .Include(x => x.Course)
                        .Include(x => x.Student)
                        .FirstOrDefaultAsync(w => w.StudentID == studentId && w.CourseID == courseId);
        }

        public async Task<List<StudentCourses>> GetAll()
        {
            return await _schoolContext.StudentCourses
                .Include(x => x.Course)
                .Include(x => x.Student)
                .ToListAsync();
        }

        public async Task<List<StudentCourses>> GetByCourseId(int courseId)
        {
            return await _schoolContext.StudentCourses
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Where(w => w.CourseID == courseId)
                .ToListAsync();
        }

        public async Task<List<StudentCourses>> GetByCourseName(string name)
        {
            return await _schoolContext.StudentCourses
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Where(w => w.Course!.Name!.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }

        public async Task<List<StudentCourses>> GetByStudentId(int studentId)
        {
            return await _schoolContext.StudentCourses
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Where(w => w.StudentID == studentId)
                .ToListAsync();
        }

        public async Task<List<StudentCourses>> GetByStudentName(string name)
        {
            return await _schoolContext.StudentCourses
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Where(w => w.Student!.Name!.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }

        public async Task Update(StudentCourses studentCourses)
        {
            _schoolContext.StudentCourses.Update(studentCourses);
            await _schoolContext.SaveChangesAsync();
        }
    }
}
