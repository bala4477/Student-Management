using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AspCore1.Models
{
    public class Student
    {
        [Required]
        [ForeignKey("Departments")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentEmail { get; set; }
        [Required]
        public string StudentPhone { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        public string StudentPhoto { get; set; }

        public List<Marks> marks { get; set; }

    }
}
