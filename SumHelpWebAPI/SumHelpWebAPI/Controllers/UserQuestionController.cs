using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumHelpWebAPI.Models;
using SumHelpWebAPI.Data;
using System;

namespace SumHelpWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserQuestionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserQuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserQuestions()
        {
            var userQuestions = await _context.UserQuestions.ToListAsync();
            return Ok(userQuestions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserQuestion(Guid id)
        {
            var userQuestion = await _context.UserQuestions.FindAsync(id);
            if (userQuestion == null)
            {
                return NotFound();
            }
            return Ok(userQuestion);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserQuestion(UserQuestionModel userQuestion)
        {
            _context.UserQuestions.Add(userQuestion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserQuestion), new { id = userQuestion.Id }, userQuestion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserQuestion(Guid id, UserQuestionModel userQuestion)
        {
            if (id != userQuestion.Id)
            {
                return BadRequest();
            }

            _context.Entry(userQuestion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserQuestion(Guid id)
        {
            var userQuestion = await _context.UserQuestions.FindAsync(id);
            if (userQuestion == null)
            {
                return NotFound();
            }

            _context.UserQuestions.Remove(userQuestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
