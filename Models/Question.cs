using System.ComponentModel.DataAnnotations;

namespace NewQuizApp.Models;

public class Question
{
    [Key]
    public int QuestionId { get; set; }
    public string? Mcq { get; set; }
    public string? OpenQuestion { get; set; }
}