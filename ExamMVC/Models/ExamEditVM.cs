using System.ComponentModel.DataAnnotations.Schema;

namespace ExamMVC.Models
{
    public class ExamEditVM
    {
        public List<StudentsVM> Students { get; set; }
        public List<LessonsVM> Lessons { get; set; }

        public ExamVM Exam { get; set; }
       
     
    }
}
