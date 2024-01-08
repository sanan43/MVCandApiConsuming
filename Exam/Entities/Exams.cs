using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Entities
{
    public class Exams
    {
        public int Id { get; set; }
        [Column(TypeName = "char(3)")]
        public int DersinKodu { get; set; }
        [Column(TypeName = "tinyint")]
        public int SagirdinNomresi { get; set; }
        public DateTime ImtahanTarixi { get; set; }
        public Decimal Qiymeti { get; set; }
        public ICollection<Students> Students { get; set; }
    }
}
