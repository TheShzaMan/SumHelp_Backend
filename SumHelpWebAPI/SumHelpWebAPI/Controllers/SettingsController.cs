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
    public class SettingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSettings()
        {
            var settings = await _context.Settings.ToListAsync();
            return Ok(settings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSetting(Guid id)
        {
            var setting = await _context.Settings.FindAsync(id);
            if (setting == null)
            {
                return NotFound();
            }
            return Ok(setting);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSetting(SettingsModel setting)
        {
            _context.Settings.Add(setting);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSetting), new { id = setting.Id }, setting);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSetting(Guid id, SettingsModel setting)
        {
            if (id != setting.Id)
            {
                return BadRequest();
            }

            _context.Entry(setting).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSetting(Guid id)
        {
            var setting = await _context.Settings.FindAsync(id);
            if (setting == null)
            {
                return NotFound();
            }

            _context.Settings.Remove(setting);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
