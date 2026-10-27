using EF_Teste.Data;
using EF_Teste.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EF_Teste.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _schoolContext;

        public CourseRepository(SchoolContext context)
        {
            _schoolContext = context;
        }

        public async Task Create(Course course)
        {
            await _schoolContext.Courses.AddAsync(course);
            await _schoolContext.SaveChangesAsync();
        }

        public async Task Delete(Course course)
        {
            _schoolContext.Courses.Remove(course);
            await _schoolContext.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAll()
        {
            var data = await _schoolContext.Courses.ToListAsync();
            return data;
        }

        public async Task<Course> GetById(int id)
        {
            var course = await _schoolContext.Courses.Where(s => s.ID == id).FirstOrDefaultAsync();
            return course;
        }

        public async Task<List<Course>> GetByName(string name)
        {
            var course = await _schoolContext.Courses.Where(s => s.Name!.ToLower().Contains(name.ToLower())).ToListAsync();

            return course;
        }

        public async Task Update(Course course)
        {
            _schoolContext.Courses.Update(course);
            await _schoolContext.SaveChangesAsync();
        }
    }
}
