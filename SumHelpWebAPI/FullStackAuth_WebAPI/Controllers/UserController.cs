using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    //private readonly RevenueCatService _revenueCatService;

    public UserController(ApplicationDbContext context) //RevenueCatService revenueCatService) <<<Add this once RevenueCat has been added
    {
        _context = context;
        //_revenueCatService = revenueCatService;
    }

    // GET: api/User/{id}
    //[HttpGet("{id}")]
    //public async Task<ActionResult<UserModel>> GetUser(Guid id)
    //{
    //    var user = await _context.AppUsers.Include(u => u.UserQuestions).Include(u => u.Reports).FirstOrDefaultAsync(u => u.UserId == id);

    //    if (user == null)
    //    {
    //        return NotFound();
    //    }

    //// Sync subscription status with RevenueCat
    //user = await _revenueCatService.SyncSubscriptionStatus(user);
    //_context.Entry(user).State = EntityState.Modified;
    //await _context.SaveChangesAsync();

    //return Ok(user);
    //}

    // Other CRUD operations remain the same...
    [HttpGet("{id}")]
    public async Task<ActionResult<UserModel>> GetUser(Guid id)
    {
        var user = await _context.AppUsers.Include(u => u.UserQuestions).Include(u => u.Reports).FirstOrDefaultAsync(u => u.UserId == id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    // PUT: api/User/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, UserModel userModel)
    {
        if (id != userModel.UserId)
        {
            return BadRequest();
        }

        _context.Entry(userModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
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

    // POST: api/User
    [HttpPost]
    public async Task<ActionResult<UserModel>> CreateUser(UserModel userModel)
    {
        _context.AppUsers.Add(userModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = userModel.UserId }, userModel);
    }

    // DELETE: api/User/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var user = await _context.AppUsers.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.AppUsers.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UserExists(Guid id)
    {
        return _context.AppUsers.Any(e => e.UserId == id);
    }

}