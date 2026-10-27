using EF_Teste.Models;

namespace EF_Teste.ViewModels.StudentCourses
{
    public class StudentCoursesViewModel
    {
        public int StudentId { get; set; }
        public List<Student> Students { get; set; } = [];
        public List<SelectedCourses> Courses { get; set; } = [];

        public void SetCourses(List<Course> courses)
        {
            Courses = [.. courses.Select(c=> new SelectedCourses
                {
                    Id=c.ID,
                    Name=c.Name!,
                    isSelected=false
                })
            ];


        }
    }

    public class SelectedCourses
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool isSelected { get; set; }
    }
}
