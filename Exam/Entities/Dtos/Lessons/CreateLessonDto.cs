using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Entities.Dtos.Lessons
{
    public class CreateLessonDto
    {
        public int DersinKodu { get; set; }
        
        public string DersinAdi { get; set; }
       
        public byte Sinifi { get; set; }
      
        public string MuellimAdi { get; set; }
     
        public string MuellimSoyadi { get; set; }
    }
}
