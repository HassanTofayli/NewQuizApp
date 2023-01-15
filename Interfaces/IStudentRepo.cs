namespace NewQuizApp.Interfaces;
using NewQuizApp.Models;


public interface IStudentRepo
{
    Task<List<Student>> GetAllStudentAsync();
    Task<Student?> GetStudentByIdAsync(int id);
    Task<bool> AddStudentAsync(Student newStudent);
    Task<bool> DeleteStudentAsync(int id);
    Task<bool> UpdatStudentAsync(Student updatedStudent);
}