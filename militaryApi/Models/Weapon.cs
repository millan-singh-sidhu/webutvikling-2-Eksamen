using System.ComponentModel.DataAnnotations;

namespace militaryApi.Models;

public class Weapon
{
    [Key]
    public int Id { get; set; }

    public String? WeaponImage { get; set; }

    public String? WeaponName { get; set; }

    public String? WeaponType { get; set; }

    public int AmmoCapacity { get; set; }

    public String? AmmoType { get; set; }

    public Boolean? Automatic { get; set; }

    public Boolean? SemiAutomatic { get; set; }

    public Boolean? SingelFire { get; set; }
}