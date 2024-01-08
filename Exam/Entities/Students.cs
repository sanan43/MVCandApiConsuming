using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Entities
{
    public class Students
    {
        public int Id { get; set; }
        [Column(TypeName = "tinyint")]
        public int SagirdinNomresi { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Ad { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Soyad { get; set; }
        [Column(TypeName = "tinyint")]
        public int Sinifi { get; set; }
        public ICollection<Lessons> Lessons { get; set; }
        public ICollection<Exams> Exams { get; set; }

    }
}
