#nullable disable
using Microsoft.EntityFrameworkCore;

namespace militaryApi.Models;

public class militaryApiContext : DbContext
{
    public militaryApiContext(DbContextOptions<militaryApiContext> options):base(options)
    {}
    public DbSet<militaryApi.Models.Soldier> Soldier { get; set;}

    public DbSet<militaryApi.Models.Weapon> Weapon {get; set;}

}