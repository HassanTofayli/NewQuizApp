using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace NewQuizApp.Models;

public class Quiz
{
    [Key]
    public int QuizId { get; set; }

    public string Title { get; set; } = null!;
    
    public int ClassRoomId { get; set; }
    public Classroom Classroom { get; set; } = null!;

    public List<Question> Questions { get; set; } = null!;
}