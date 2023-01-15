using Microsoft.EntityFrameworkCore;
using NewQuizApp.Data;
using NewQuizApp.Interfaces;
using NewQuizApp.Models;

namespace NewQuizApp.Repos;

public class ClassroomRepo : IClassroomRepo
{
    
    private readonly AppDbContext _db;

    public ClassroomRepo(AppDbContext db)
    {
        this._db=db;
    }
    
    
    
    public async Task<List<Classroom>> GetAllClassroomsAsync()
    {
        var classRooms = await _db.Classrooms.ToListAsync<Classroom>();

        if (classRooms == null)
            return new List<Classroom>();
        return classRooms;    }

    public async Task<Classroom?> GetClassroomByIdAsync(int id)
    {
        var classRooms = await _db.Classrooms.FindAsync(id);
        return classRooms;    }

    public async Task<bool> AddClassroomAsync(Classroom newClassroom)
    {
        _db.Classrooms.Add(newClassroom);
        return await _db.SaveChangesAsync() > 0;
        
    }

    public async Task<bool> DeleteClassroomAsync(int id)
    {
        var ClassroomToBeDeleted = await GetClassroomByIdAsync(id);
        if (ClassroomToBeDeleted == null) return false;

        _db.Classrooms.Remove(ClassroomToBeDeleted); // in memory operation
        var success = await _db.SaveChangesAsync() > 0; // this actualy writes it to the database
        return success;
    }

    public async Task<bool> UpdateClassroomAsync(Classroom updatedClassroom)
    {
        var ClassroomToBeUpdated = await GetClassroomByIdAsync(updatedClassroom.ClassroomId);
        if (ClassroomToBeUpdated == null) return false;

        ClassroomToBeUpdated.ClassroomId = updatedClassroom.ClassroomId;
        ClassroomToBeUpdated.Quizzes = updatedClassroom.Quizzes;
        ClassroomToBeUpdated.Teacher = updatedClassroom.Teacher;
        ClassroomToBeUpdated.TeacherId = updatedClassroom.TeacherId;
        ClassroomToBeUpdated.course_name = updatedClassroom.course_name;
        ClassroomToBeUpdated.teacher_name = updatedClassroom.teacher_name;
        
        _db.Classrooms.Update(ClassroomToBeUpdated); // in memory operation
        var success = await _db.SaveChangesAsync() > 0; // this actualy writes it to the database
        return success;    }
}