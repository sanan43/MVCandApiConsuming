using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Entities.Dtos.Exams
{
    public class UpdateExamDto
    {
        public int Id { get; set; }
     
        public int DersinKodu { get; set; }
   
        public int SagirdinNomresi { get; set; }
        public DateTime ImtahanTarixi { get; set; }
        public Decimal Qiymeti { get; set; }
        
    }
}
