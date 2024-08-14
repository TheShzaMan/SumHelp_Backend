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
    public class ErrorLogController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ErrorLogController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetErrorLogs()
        {
            var errorLogs = await _context.ErrorLogs.ToListAsync();
            return Ok(errorLogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetErrorLog(Guid id)
        {
            var errorLog = await _context.ErrorLogs.FindAsync(id);
            if (errorLog == null)
            {
                return NotFound();
            }
            return Ok(errorLog);
        }

        [HttpPost]
        public async Task<IActionResult> CreateErrorLog(ErrorLogModel errorLog)
        {
            _context.ErrorLogs.Add(errorLog);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetErrorLog), new { id = errorLog.Id }, errorLog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateErrorLog(Guid id, ErrorLogModel errorLog)
        {
            if (id != errorLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(errorLog).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErrorLog(Guid id)
        {
            var errorLog = await _context.ErrorLogs.FindAsync(id);
            if (errorLog == null)
            {
                return NotFound();
            }

            _context.ErrorLogs.Remove(errorLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
