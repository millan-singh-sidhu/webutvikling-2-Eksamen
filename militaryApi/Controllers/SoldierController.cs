#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using militaryApi.Models;

namespace soldier.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SoldierController : ControllerBase
{
    private readonly militaryApiContext _context;
    public SoldierController(militaryApiContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<List<Soldier>>> get()
    {
        List<Soldier> soldier = await _context.Soldier.ToListAsync();

        if(soldier != null)
        {
            return Ok(soldier);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Soldier>> Get(int id)
    {
        Soldier soldier = await _context.Soldier.FindAsync(id);
        return soldier;
    }

    [HttpPut]
    public async Task<ActionResult<Soldier>> put(Soldier editedSoldier)
    {
        _context.Entry(editedSoldier).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return editedSoldier;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Soldier newSoldier)
    {
        _context.Soldier.Add(newSoldier);
        await _context.SaveChangesAsync();
        return StatusCode(201); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Soldier soldier = await _context.Soldier.FindAsync(id);
        _context.Soldier.Remove(soldier);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}