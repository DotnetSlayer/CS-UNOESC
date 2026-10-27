using EF_Teste.Data;
using EF_Teste.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return await _context.Students
                .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                .ToListAsync();
        }

        public async Task<List<Student>> GetAllNotEnrolled()
        {
            var enrolledStudentIds = await _context.StudentCourses
                .Select(sc => sc.StudentID)
                .Distinct()
                .ToListAsync();

            var data = await _context.Students
                .Where(s => !enrolledStudentIds.Contains(s.ID))
                .ToListAsync();

            return data;
        }

        public async Task<Student?> GetById(int id)
        {
            return await _context.Students
                .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                .FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task<List<Student>> GetByName(string name)
        {
            return await _context.Students
                .Where(s => s.FirstMidName != null && s.FirstMidName.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }

        public async Task Update(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
