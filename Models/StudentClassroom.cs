using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NewQuizApp.Models;

public class StudentClassroom
{
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public int ClassroomId { get; set; }
    public Classroom Classroom { get; set; } = null!;
}

public class ClassroomConfig : IEntityTypeConfiguration<StudentClassroom>
{
    public void Configure(EntityTypeBuilder<StudentClassroom> builder)
    {
        builder.HasKey(x => new { x.StudentId, x.ClassroomId }); // Creates a composite primary key
    }
}