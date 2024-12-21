using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbContextFactory<BookDBContext> _contextFactory;
        public StudentRepository(IDbContextFactory<BookDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<Student> CreateStudent(Student student)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext()) 
            {
                    context.Students.Add(student);
                    await context.SaveChangesAsync();
                    return student;
            } 
        }

        public async Task<bool> DeleteStudent(Student student)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                Student st= await context.Students.FindAsync(student);
                context.Students.Remove(st);
                
                return await context.SaveChangesAsync()>0;
            }
        }

        public async Task<List<Student>> GetStudent()
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                List<Student> students = await context.Students.ToListAsync();
                return students;
            }
           
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                context.Students.Update(student);
                await context.SaveChangesAsync();
                return student;
            }
        }
    }
}
