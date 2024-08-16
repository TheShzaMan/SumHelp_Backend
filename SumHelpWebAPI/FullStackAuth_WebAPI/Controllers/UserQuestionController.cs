
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class UserQuestionController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UserQuestionController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/UserQuestion/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<UserQuestionModel>> GetUserQuestion(Guid id)
    {
        var userQuestion = await _context.UserQuestions.Include(q => q.User).FirstOrDefaultAsync(q => q.Id == id);

        if (userQuestion == null)
        {
            return NotFound();
        }

        return Ok(userQuestion);
    }

    // GET: api/UserQuestion/user/{userId}
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<UserQuestionModel>>> GetUserQuestionsByUser(Guid userId)
    {
        var userQuestions = await _context.UserQuestions.Where(q => q.UserId == userId).ToListAsync();

        return Ok(userQuestions);
    }

    // POST: api/UserQuestion
    [HttpPost]
    public async Task<ActionResult<UserQuestionModel>> CreateUserQuestion(UserQuestionModel userQuestionModel)
    {
        _context.UserQuestions.Add(userQuestionModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUserQuestion), new { id = userQuestionModel.Id }, userQuestionModel);
    }

    // DELETE: api/UserQuestion/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserQuestion(int id)
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

    private bool UserQuestionExists(Guid id)
    {
        return _context.UserQuestions.Any(e => e.Id == id);
    }
}