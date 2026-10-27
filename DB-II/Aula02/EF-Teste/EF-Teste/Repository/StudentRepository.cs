using EF_Teste.Data;
using EF_Teste.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Teste.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;

        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task Create(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAll()
        {
            var data = await _context.Students.Include(sc => sc.StudentCourses).ToListAsync(c => c.Courses);
            return data;

        }

        public async Task<Student>? GetById(int id)
        {
            var student = _context.Students.Where(s => s.ID  == id).FirstOrDefault();
            return student;
        }

        public async Task<List<Student>> GetByName(string name)
        {
            var student = await _context.Students.Where(s => s.FirstMidName!.ToLower().Contains(name.ToLower())).ToListAsync();
            return student;
        }

        public async Task Update(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
