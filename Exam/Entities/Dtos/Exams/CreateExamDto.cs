namespace Exam.Entities.Dtos.Exams
{
    public class CreateExamDto
    {
        
        public int DersinKodu { get; set; }

        public int SagirdinNomresi { get; set; }
        public DateTime ImtahanTarixi { get; set; }
        public Decimal Qiymeti { get; set; }
    }
}
