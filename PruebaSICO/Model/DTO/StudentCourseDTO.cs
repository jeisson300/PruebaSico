namespace PruebaSICO.Model.DTO
{
    public class StudentCourseDTO
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }
    }


    public class StudentCourseReponseDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public string Description { get; set; } = "";
    }

    public class StudentFilterDTO
    {
        public string Filter { get; set; } = "";
    }
}
