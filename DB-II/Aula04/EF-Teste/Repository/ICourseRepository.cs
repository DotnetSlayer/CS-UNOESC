using EF_Teste.Models;

namespace EF_Teste.Repository
{
    public interface ICourseRepository
    {
        public Task Create(Course course);
        public Task Update(Course course);
        public Task Delete(Course course);
        public Task<Course?> GetById(int id);
        public Task<List<Course>> GetAll();
        public Task<List<Course>> GetByName(string name);
    }
}
