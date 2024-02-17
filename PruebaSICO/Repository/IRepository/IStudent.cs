using PruebaSICO.Model;
using PruebaSICO.Model.DTO;

namespace PruebaSICO.Repository.IRepository
{
    public interface IStudent
    {
        public Task<ICollection<Student>> GetAllAsync();

        public Task<ICollection<Student>> GetAllByFilterAsync(string filter);

        public Task<ICollection<StudentCourseReponseDTO>> GetAllStudentCourseOwnAsync(int IdStudent);
        public Task<ICollection<StudentCourseReponseDTO>> GetAllStudentCourseNoOwnAsync(int IdStudent);

    }
}
