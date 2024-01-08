using System.ComponentModel.DataAnnotations.Schema;

namespace ExamMVC.Models
{
    public class LessonsVM
    {
        public int Id { get; set; }
      
        public int DersinKodu { get; set; }
       
        public string DersinAdi { get; set; }
        
        public byte Sinifi { get; set; }
    
        public string MuellimAdi { get; set; }
        
        public string MuellimSoyadi { get; set; }
        
    }
}
