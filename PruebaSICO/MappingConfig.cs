using AutoMapper;
using PruebaSICO.Model;
using PruebaSICO.Model.DTO;

namespace PruebaSICO
{
    public class MappingConfig: Profile
    {

        public MappingConfig()
        {
            CreateMap<StudentCourse, StudentCourseDTO>();
            CreateMap<StudentCourseDTO, StudentCourse>();
        }
    }
}
