using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Entities.Dtos.Students
{
    public class UpdateStudentDto
    {
        public int Id { get; set; }
       
        public int SagirdinNomresi { get; set; }
    
        public string Ad { get; set; }
     
        public string Soyad { get; set; }
       
        public int Sinifi { get; set; }
    }
}
