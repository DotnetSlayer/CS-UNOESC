using EF_Teste.Models;

namespace EF_Teste.Repository
{
    public interface IStudentCoursesRepository
    {
        public Task Create(StudentCourses studentCourses);
        public Task Update(StudentCourses studentCourses);
        public Task Delete(StudentCourses studentCourses);

        public Task<List<StudentCourses>>? GetByStudentId(int studentId);
        public Task<List<StudentCourses>>? GetByCourseId(int courseId);
        public Task<List<StudentCourses>> Get(int studentId, int courseId);
        public Task<List<StudentCourses>> GetAll();
        public Task<List<StudentCourses>> GetByCourseName(string name);
        public Task<List<StudentCourses>> GetByStudentName(string name);
    }
}
