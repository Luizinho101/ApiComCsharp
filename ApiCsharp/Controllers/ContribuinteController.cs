using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCsharp.Data;
using ApiCsharp.Models;

[Route("api/[controller]")]
[ApiController]
public class ContribuinteController : ControllerBase
{
    private readonly AppDbContext _context;

    public ContribuinteController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Contribuinte
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contribuinte>>> GetContribuintes()
    {
        return await _context.Contribuintes.ToListAsync();
    }

    // GET: api/Contribuinte/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Contribuinte>> GetContribuinte(int id)
    {
        var contribuinte = await _context.Contribuintes.FindAsync(id);

        if (contribuinte == null)
        {
            return NotFound();
        }

        return contribuinte;
    }

    // POST: api/Contribuinte
    [HttpPost]
    public async Task<ActionResult<Contribuinte>> PostContribuinte(Contribuinte contribuinte)
    {
        _context.Contribuintes.Add(contribuinte);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetContribuinte), new { id = contribuinte.Id }, contribuinte);
    }

    // PUT: api/Contribuinte/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutContribuinte(int id, Contribuinte contribuinte)
    {
        if (id != contribuinte.Id)
        {
            return BadRequest();
        }

        _context.Entry(contribuinte).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ContribuinteExists(id))
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

    // DELETE: api/Contribuinte/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContribuinte(int id)
    {
        var contribuinte = await _context.Contribuintes.FindAsync(id);
        if (contribuinte == null)
        {
            return NotFound();
        }

        _context.Contribuintes.Remove(contribuinte);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ContribuinteExists(int id)
    {
        return _context.Contribuintes.Any(e => e.Id == id);
    }
}




