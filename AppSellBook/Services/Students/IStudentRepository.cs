using AppSellBook.Entities;

namespace AppSellBook.Services.Students
{
    public interface IStudentRepository
    {
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<bool> DeleteStudent(Student student);
        Task<List<Student>> GetStudent();
    }
}
