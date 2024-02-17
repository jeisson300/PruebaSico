using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaSICO.Model
{
    public class Student
    {


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Identification { get; set; }
        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";

    }
}
