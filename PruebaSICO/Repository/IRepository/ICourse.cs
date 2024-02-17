using PruebaSICO.Model;

namespace PruebaSICO.Repository.IRepository
{
    public interface ICourse
    {
        public Task<ICollection<Course>> GetAllAsync();

        public Task SaveStudentCourse(StudentCourse studentCourse);

        public Task<StudentCourse> GetStudentCourse(int studentCourseId);
        public Task DeleteStudentCourse(StudentCourse studentCourse);
    }
}
