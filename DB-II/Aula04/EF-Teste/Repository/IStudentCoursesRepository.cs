using EF_Teste.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EF_Teste.Repository
{
    public interface IStudentCoursesRepository
    {
        Task Create(StudentCourses studentCourses);
        Task Delete(StudentCourses studentCourses);
        Task<List<StudentCourses>> Get(int studentId, int courseId);
        Task<List<StudentCourses>> GetAll();
        Task<List<StudentCourses>> GetByCourseId(string name);
        Task<List<StudentCourses>> GetByCourseName(string name);
        Task<List<StudentCourses>> GetByStudentCoursesId(int studentId);
        Task<List<StudentCourses>> GetByStudentName(string name);
        Task Update(StudentCourses studentCourses);
    }
}
