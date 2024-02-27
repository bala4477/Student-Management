using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCore1.Models
{
    public class Marks
    {
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public Student Student { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MarkID { get; set; }
        [Required]
        public int SubjectID_1 { get; set; }
        [Required]
        public string SubjectName_1 { get; set; }
        [Required]
        public int Subject_1_Mark { get; set; }
        [Required]
        public int SubjectID_2 { get; set; }
        [Required]
        public string SubjectName_2 { get; set; }
        [Required]
        public int Subject_2_Mark { get; set; }
        [Required]
        public int SubjectID_3 { get; set; }
        [Required]
        public string SubjectName_3 { get; set; }
        [Required]
        public int Subject_3_Mark { get; set; }
        [Required]
        public int SubjectID_4 { get; set; }
        [Required]
        public string SubjectName_4 { get; set; }
        [Required]
        public int Subject_4_Mark { get; set; }
        [Required]
        public int SubjectID_5 { get; set; }
        [Required]
        public string SubjectName_5 { get; set; }
        [Required]
        public int Subject_5_Mark { get; set; }
        [Required]
        public int SubjectID_6 { get; set; }
        [Required]
        public string SubjectName_6 { get; set; }
        [Required]
        public int Subject_6_Mark { get; set; }

        public int Total { get; set; }

        public int Rank { get; set; }

        public static List<Marks> Mark;

        static Marks()
        {
            Mark = new List<Marks>();
        }


        public static void CalculateTotal(Marks Mark)
        {
            Mark.Total = Mark.Subject_1_Mark + Mark.Subject_2_Mark + Mark.Subject_3_Mark + Mark.Subject_4_Mark + Mark.Subject_5_Mark + Mark.Subject_6_Mark;
        }
        public static void UpdateRanks(List<Marks> Mark)
        {
            if (Mark != null && Mark.Any())
            {
                // Sort the students by total marks in descending order
                Mark = Mark.OrderByDescending(student => student.Total).ToList();

                // Update the rank for each student in the sorted list
                for (int i = 0; i < Mark.Count; i++)
                {
                    Mark[i].Rank = i + 1;
                }
            }
        }


    }
}
