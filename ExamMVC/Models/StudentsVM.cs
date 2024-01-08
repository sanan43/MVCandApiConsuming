using System.ComponentModel.DataAnnotations.Schema;

namespace ExamMVC.Models
{
    public class StudentsVM
    {
        public int Id { get; set; }
       
        public int SagirdinNomresi { get; set; }
        
        public string Ad { get; set; }
        
        public string Soyad { get; set; }
      
        public int Sinifi { get; set; }
    }
}
