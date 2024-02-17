using Microsoft.EntityFrameworkCore;
using PruebaSICO.DB;
using PruebaSICO.Model;
using PruebaSICO.Model.DTO;
using PruebaSICO.Repository.IRepository;

namespace PruebaSICO.Repository
{
    public class StudentRepository : IStudent
    {
        private TodoContext _db;
        public StudentRepository(TodoContext db)
        {
            _db = db;
        }

        public async Task<ICollection<Student>> GetAllAsync()
        {
            ICollection<Student> student = new List<Student>();
            try
            {
                IQueryable<Student> query = from s in _db.Student
                                            select s;
                student = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return student;
        }

        public async Task<ICollection<Student>> GetAllByFilterAsync(string filter)
        {
            ICollection<Student> student = new List<Student>();
            try
            {
                IQueryable<Student> query = from s in _db.Student
                                            where s.Name.Equals(filter) || s.Email.Equals(filter)
                                            || s.LastName.Equals(filter) || Convert.ToString(s.Identification).Equals(filter)
                                            select s;
                student = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return student;
        }

        public async Task<ICollection<StudentCourseReponseDTO>> GetAllStudentCourseNoOwnAsync(int IdStudent)
        {

            ICollection<StudentCourseReponseDTO> studentCourse = new List<StudentCourseReponseDTO>();
            try
            {
                ICollection<StudentCourseReponseDTO> studentOwnCourse = await GetAllStudentCourseOwnAsync(IdStudent);
                List<int> courserIdOwnStudent = new();
                foreach (StudentCourseReponseDTO item in studentOwnCourse)
                {
                    courserIdOwnStudent.Add(item.CourseId);
                }

                IQueryable<StudentCourseReponseDTO> query = (from c in _db.Course
                                                             join sc in _db.StudentCourse on c.Id equals sc.CourseId into StudentCourse
                                                             from stc2 in StudentCourse.DefaultIfEmpty()
                                                             where !courserIdOwnStudent.Contains(c.Id)
                                                             select new StudentCourseReponseDTO
                                                             {
                                                                 CourseId = c.Id,
                                                                 StudentId = IdStudent,
                                                                 Description = c.Description
                                                             }).Distinct();
                studentCourse = await query.ToListAsync();

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return studentCourse;
        }

        public async Task<ICollection<StudentCourseReponseDTO>> GetAllStudentCourseOwnAsync(int IdStudent)
        {
            ICollection<StudentCourseReponseDTO> studentCourse = new List<StudentCourseReponseDTO>();
            try
            {
                IQueryable<StudentCourseReponseDTO> query = from sc in _db.StudentCourse
                                                            join c in _db.Course on sc.CourseId equals c.Id
                                                            where sc.StudentId == IdStudent
                                                            select new StudentCourseReponseDTO
                                                            {
                                                                Id = sc.Id,
                                                                StudentId = sc.StudentId,
                                                                CourseId = sc.CourseId,
                                                                Description = c.Description
                                                            };
                studentCourse = await query.ToListAsync();

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return studentCourse;
        }
    }
}
