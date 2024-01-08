using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Entities
{
    public class Lessons
    {
        public int Id { get; set; }
        [Column(TypeName ="char(3)")]
        public int DersinKodu { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string DersinAdi { get; set; }
        [Column(TypeName = "tinyint")]
        public byte Sinifi { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string MuellimAdi { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string MuellimSoyadi { get; set; }
        public ICollection<Exams> Exams { get; set; }
        public ICollection<Students> Students { get; set; }
    }
}
