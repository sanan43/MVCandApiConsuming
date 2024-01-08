using System.ComponentModel.DataAnnotations.Schema;

namespace ExamMVC.Models
{
    public class ExamVM
    {
        public int Id { get; set; }
        
        public int DersinKodu { get; set; }
       
        public int SagirdinNomresi { get; set; }
        public DateTime ImtahanTarixi { get; set; }
        public Decimal Qiymeti { get; set; }

       

    }
}
