using System.ComponentModel.DataAnnotations;


namespace NewQuizApp.Models;

public class Classroom
{
    [Key]
    public int ClassroomId { get; set; }
    [Required]
    public string teacher_name { get; set; } = null!;
    public string course_name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;
    public ICollection<StudentClassroom> Classrooms { get; set; } = new List<StudentClassroom>();
    public List<Quiz>? Quizzes { get; set; }
}