using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace EF_Teste.Models
{
    public class Course
    {
        [Key] // Referenciando chave primária
        public int ID { get; set; }
        public string? Name { get; set; }

        public List<StudentCourses>? StudentCourses { get; set; }
    }
}
