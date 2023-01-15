using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewQuizApp.Models;

public class Teacher
{
    [Key]
    public int TeacherId { get; set; }
    public string teacher_name { get; set; } = null!;
    public string teacher_email { get; set; } = null!;
    public ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();

}