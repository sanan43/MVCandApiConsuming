using Exam.DAL.EFCore;
using Exam.Entities;
using Exam.Entities.Dtos.Lessons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Exam.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonsController : Controller
    {
        private readonly AppDbContext _context;

        public LessonsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //[Route("GetLessons")]
        public async Task<IActionResult> GetLessons()
        {
            var result = await _context.Lessons.OrderByDescending(s => s.Id).ToListAsync();
            if (result.Count==0) return NotFound();
            
            return StatusCode((int)HttpStatusCode.OK,result);
        }

        [HttpGet]
        //[Route("GetLessonById/{id}")]
        public async Task<IActionResult> GetLessonById(int id)
        {
            var result = await _context.Lessons.Where(b=>b.Id==id).FirstOrDefaultAsync();
            if (result is null) return NotFound();

            return StatusCode((int)HttpStatusCode.OK, result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateLessonDto LessonDto)
        {
            Lessons lessons = new Lessons
            {
                DersinAdi = LessonDto.DersinAdi,
                DersinKodu = LessonDto.DersinKodu,
                Sinifi = LessonDto.Sinifi,
                MuellimAdi = LessonDto.MuellimAdi,
                MuellimSoyadi = LessonDto.MuellimSoyadi
            };

            await _context.Lessons.AddAsync(lessons);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateLessonDto UpdateLessonDto)
        {
            var result = await _context.Lessons.FindAsync(UpdateLessonDto.Id);
            if (result is null) return NotFound();
            result.DersinKodu = UpdateLessonDto.DersinKodu;
            result.DersinAdi = UpdateLessonDto.DersinAdi;
            result.Sinifi = UpdateLessonDto.Sinifi;
            result.MuellimAdi = UpdateLessonDto.MuellimAdi;
            result.MuellimSoyadi = UpdateLessonDto.MuellimSoyadi;
            await _context.SaveChangesAsync();
            return NoContent();
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Lessons.FindAsync(id);
            if (result is null) return BadRequest(new
            {
                StatusCode=201,
                Message="Tapilmadi"
            });
            _context.Lessons.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
