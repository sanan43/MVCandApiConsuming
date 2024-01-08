namespace Exam.Entities.Dtos.Lessons
{
    public class UpdateLessonDto
    {
        public int Id { get; set; }
        public int DersinKodu { get; set; }

        public string DersinAdi { get; set; }

        public byte Sinifi { get; set; }

        public string MuellimAdi { get; set; }

        public string MuellimSoyadi { get; set; }
    }
}
