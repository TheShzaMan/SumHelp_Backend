using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ReportController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Report/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ReportModel>> GetReport(Guid id)
    {
        var report = await _context.Reports.Include(r => r.User).FirstOrDefaultAsync(r => r.ReportId == id);

        if (report == null)
        {
            return NotFound();
        }

        return Ok(report);
    }

    // POST: api/Report
    [HttpPost]
    public async Task<ActionResult<ReportModel>> CreateReport(ReportModel reportModel)
    {
        _context.Reports.Add(reportModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetReport), new { id = reportModel.ReportId }, reportModel);
    }

    // PUT: api/Report/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReport(Guid id, ReportModel reportModel)
    {
        if (id != reportModel.ReportId)
        {
            return BadRequest();
        }

        _context.Entry(reportModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReportExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Report/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReport(Guid id)
    {
        var report = await _context.Reports.FindAsync(id);
        if (report == null)
        {
            return NotFound();
        }

        _context.Reports.Remove(report);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ReportExists(Guid id)
    {
        return _context.Reports.Any(e => e.ReportId == id);
    }
}