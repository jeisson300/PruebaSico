using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaSICO.Model
{
    public class StudentCourse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int Id { get; set; }

        public int StudentId { get; set; }  

        public int CourseId { get; set; }
    }
}
