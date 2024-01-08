using Exam.DAL.EFCore;
using Exam.Entities.Dtos.Lessons;
using Exam.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Exam.Entities.Dtos.Students;

namespace Exam.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
       //[Route("GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            var result = await _context.Students.OrderByDescending(s => s.Id).ToListAsync();
            if (result.Count == 0) return NotFound();

            return StatusCode((int)HttpStatusCode.OK, result);
        }

        [HttpGet]
       //[Route("GetStudentById/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var result = await _context.Students.Where(b => b.Id == id).FirstOrDefaultAsync();
            if (result is null) return NotFound();

            return StatusCode((int)HttpStatusCode.OK, result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto createStudentDto)
        {
            Students students = new Students
            {
                SagirdinNomresi=createStudentDto.SagirdinNomresi,
                Ad=createStudentDto.Ad,
                Soyad=createStudentDto.Soyad,
                Sinifi=createStudentDto.Sinifi
                
            };

            await _context.Students.AddAsync(students);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentDto UpdateStudentDto)
        {
            var result = await _context.Students.FindAsync(UpdateStudentDto.Id);
            if (result is null) return NotFound();

            result.Sinifi=UpdateStudentDto.Sinifi;
            result.SagirdinNomresi = UpdateStudentDto.Sinifi;
            result.Ad=UpdateStudentDto.Ad;
            result.Soyad=UpdateStudentDto.Soyad;
            
            await _context.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Students.FindAsync(id);
            if (result is null) return BadRequest(new
            {
                StatusCode = 201,
                Message = "Tapilmadi"
            });
            _context.Students.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}
