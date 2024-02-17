using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PruebaSICO.DB;
using PruebaSICO.Model;
using PruebaSICO.Repository.IRepository;

namespace PruebaSICO.Repository
{
    public class CourseRepository : ICourse
    {
        private TodoContext _db;
        public CourseRepository(TodoContext db)
        {
            _db = db;
        }
        public async Task<ICollection<Course>> GetAllAsync()
        {
            ICollection<Course> Listcourse = new List<Course>();
            try
            {
                IQueryable<Course> query = from c in _db.Course
                                           select c;
                Listcourse = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return Listcourse;
        }

        public async Task<StudentCourse> GetStudentCourse(int studentCourseId)
        {
            StudentCourse studentCourse = new();
            try
            {
                IQueryable<StudentCourse> query = from sc in _db.StudentCourse
                                                  where sc.Id == studentCourseId
                                                  select sc;
                studentCourse = await query.FirstOrDefaultAsync() ?? new StudentCourse();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return studentCourse;
        }
        private bool ValidateCoursebyStudentId(StudentCourse studentCourse)
        {
            bool validate = false;
            try
            {
                IQueryable<StudentCourse> query = from sc in _db.StudentCourse
                                                  where sc.CourseId == studentCourse.CourseId
                                                  && sc.StudentId == studentCourse.StudentId
                                                  select sc;
                List<StudentCourse> studentCourseResult = query.ToList();
                if (studentCourseResult.Count == 0)
                {
                    validate = true;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return validate;
        }
        public async Task SaveStudentCourse(StudentCourse studentCourse)
        {
            try
            {
                if (ValidateCoursebyStudentId(studentCourse))
                {
                    await _db.StudentCourse.AddAsync(studentCourse);
                    await _db.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public async Task DeleteStudentCourse(StudentCourse studentCourse)
        {
            try
            {
                _db.StudentCourse.Remove(studentCourse);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

    }
}
