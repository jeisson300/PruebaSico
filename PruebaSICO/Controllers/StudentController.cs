using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaSICO.Model;
using PruebaSICO.Model.DTO;
using PruebaSICO.Repository.IRepository;

namespace PruebaSICO.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;
        private readonly ICourse _course;
        private readonly IMapper _mapper;

        public StudentController(IStudent student, ICourse course, IMapper mapper)
        {
            _student = student;
            _course = course;
            _mapper = mapper;
        }

        [HttpPost("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents([FromBody] StudentFilterDTO studentFilterDTO)
        {
            if (studentFilterDTO.Filter.Equals(""))
            {
                return Ok(new { Data = await _student.GetAllAsync() });
            }
            else
            {
                return Ok(new { Data = await _student.GetAllByFilterAsync(studentFilterDTO.Filter) });
            }
        }

        [HttpGet("GetAllCourses")]
        public async Task<IActionResult> GetAllCourse()
        {
            return Ok(new { Data = await _course.GetAllAsync() });
        }


        [HttpGet("GetAllCoursesOwn/{id:int}")]
        public async Task<IActionResult> GetOwnStudentCourse(int id)
        {
            return Ok(new { Data = await _student.GetAllStudentCourseOwnAsync(id) });
        }

        [HttpGet("GetAllCoursesNoOwn/{id:int}")]
        public async Task<IActionResult> GetNoStudentCourse(int id)
        {
            return Ok(new { Data = await _student.GetAllStudentCourseNoOwnAsync(id) });
        }

        [HttpDelete("deleteStudentCourse/{id:int}")]
        public async Task<IActionResult> DeleteStudentCourse(int id)
        {

            StudentCourse studentCourse = await _course.GetStudentCourse(id);
            await _course.DeleteStudentCourse(studentCourse);
            return Ok(new { Status = true });
        }

        [HttpPost("CreateStudentCourse")]
        public async Task<IActionResult> CreateStudentCourse([FromBody] StudentCourseDTO studentCourseDTO)
        {
            StudentCourse studentCourse = _mapper.Map<StudentCourse>(studentCourseDTO);
            await _course.SaveStudentCourse(studentCourse);
            return Ok(new { Status = true });
        }
    }
}
