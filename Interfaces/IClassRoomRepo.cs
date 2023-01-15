using NewQuizApp.Models;

namespace NewQuizApp.Interfaces;

public interface IClassroomRepo
{
    Task<List<Classroom>> GetAllClassroomsAsync();
    Task<Classroom?> GetClassroomByIdAsync(int id);
    Task<bool> AddClassroomAsync(Classroom newClassroom);
    Task<bool> DeleteClassroomAsync(int id);
    Task<bool> UpdateClassroomAsync(Classroom updatedClassroom);
}