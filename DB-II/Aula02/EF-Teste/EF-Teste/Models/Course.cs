using System.ComponentModel.DataAnnotations;

namespace EF_Teste.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }

        public List<StudentCourses>? StudentCourses { get; set; }
    }
}
