using EF_Teste.Data;
using EF_Teste.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            _schoolContext.StudentCourses.Remove(studentCourses);
            await _schoolContext.SaveChangesAsync();
        }

        public async Task<List<StudentCourses>> Get(int studentId, int courseId)
        {
            var result = await _schoolContext.StudentCourses
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Where(sc => sc.StudentID == studentId && sc.CourseID == courseId)
                .ToListAsync();

            return result;
        }

        public async Task<List<StudentCourses>> GetAll()
        {
            return await _schoolContext.StudentCourses
                .Include(x => x.Course)
                .Include(x => x.Student)
                .ToListAsync();
        }

        public async Task<List<StudentCourses>> GetByCourseId(string name)
        {
            // Supondo que "name" é parte do nome do curso
            return await _schoolContext.StudentCourses
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Where(w => w.Course!.Name!.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }

        public async Task<List<StudentCourses>> GetByCourseName(string name)
        {
            // Mesmo comportamento de GetByCourseId - pode ser unificado
            return await GetByCourseId(name);
        }

        public async Task<List<StudentCourses>> GetByStudentCoursesId(int studentId)
        {
            return await _schoolContext.StudentCourses
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Where(sc => sc.StudentID == studentId)
                .ToListAsync();
        }

        public async Task<List<StudentCourses>> GetByStudentName(string name)
        {
            return await _schoolContext.StudentCourses
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Where(w => w.Student!.LastName!.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }

        public async Task Update(StudentCourses studentCourses)
        {
            _schoolContext.StudentCourses.Update(studentCourses);
            await _schoolContext.SaveChangesAsync();
        }
    }
}
