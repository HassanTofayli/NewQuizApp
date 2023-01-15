using NewQuizApp.Models;

namespace NewQuizApp.Interfaces;



public interface IQuizRepo
{
    Task<List<Quiz>> GetAllQuizzesAsync();
    Task<Quiz?> GetQuizByIdAsync(int id);
    Task<bool> AddQuizAsync(Quiz newQuiz);
    Task<bool> DeleteQuizAsync(int id);
    Task<bool> UpdateQuizAsync(Quiz updatedQuiz);
}