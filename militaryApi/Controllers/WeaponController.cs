#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using militaryApi.Models;

namespace weapon.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeaponController : ControllerBase
{
    private readonly militaryApiContext _context;
    public WeaponController(militaryApiContext context)
    {
        _context =context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Weapon>>> get()
    {
        List<Weapon> weapon = await _context.Weapon.ToListAsync();

        if(weapon != null)
        {
            return Ok(weapon);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Weapon>> Get(int id)
    {
        Weapon weapon = await _context.Weapon.FindAsync(id);
        return weapon;
    }

    [HttpPut]
    public async Task<ActionResult<Weapon>> Put(Weapon editedWeapon)
    {
        _context.Entry(editedWeapon).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return editedWeapon;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Weapon newWeapon)
    {
        _context.Weapon.Add(newWeapon);
        await _context.SaveChangesAsync();
        return StatusCode(201);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Weapon weapon = await _context.Weapon.FindAsync(id);
        _context.Weapon.Remove(weapon);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}