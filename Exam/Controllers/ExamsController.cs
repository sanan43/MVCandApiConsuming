using Exam.DAL.EFCore;
using Exam.Entities.Dtos.Lessons;
using Exam.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Exam.Entities.Dtos.Exams;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exam.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamsController : Controller
    {
        private readonly AppDbContext _context;

        public ExamsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
       // [Route("GetExams")]
        public async Task<IActionResult> GetExams()
        {
            var result = await _context.Exams.OrderByDescending(s => s.Id).ToListAsync();
            if (result.Count == 0) return NotFound();


            return StatusCode((int)HttpStatusCode.OK, result);
        }

        [HttpGet]
       // [Route("GetExamById")]
        public async Task<IActionResult> GetExamById(int id)
        {
            var result = await _context.Exams.Where(b => b.Id == id).FirstOrDefaultAsync();
            if (result is null) return NotFound();

            return StatusCode((int)HttpStatusCode.OK, result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateExamDto ExamDto)
        {
            Exams exams = new Exams
            {
                DersinKodu = ExamDto.DersinKodu,
                SagirdinNomresi = ExamDto.SagirdinNomresi,
                ImtahanTarixi = ExamDto.ImtahanTarixi,
                Qiymeti = ExamDto.Qiymeti
            };

            await _context.Exams.AddAsync(exams);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(  UpdateExamDto UpdateExamDto)
        {
            var result = await _context.Exams.FindAsync(UpdateExamDto.Id);
            if (result is null) return NotFound();
            result.SagirdinNomresi = UpdateExamDto.SagirdinNomresi;
            result.Qiymeti = UpdateExamDto.Qiymeti;
            result.ImtahanTarixi = UpdateExamDto.ImtahanTarixi;
            result.DersinKodu = UpdateExamDto.DersinKodu;

            await _context.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Exams.FindAsync(id);
            if (result is null) return BadRequest(new
            {
                StatusCode = 201,
                Message = "Tapilmadi"
            });
            _context.Exams.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        
        public async Task<IActionResult> DropDownList()
        {
            var result = await _context.Exams.OrderByDescending(s => s.Id).ToListAsync();
            if (result.Count == 0) return NotFound();

            ViewBag.dgr = result;
            return StatusCode((int)HttpStatusCode.OK, result);
        }

    }
}
