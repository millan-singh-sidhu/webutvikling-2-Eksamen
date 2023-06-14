using System.ComponentModel.DataAnnotations;

namespace militaryApi.Models;

public class Soldier
{
    [Key]
    public int Id { get; set; }

    public String? SoldierImage { get; set; }
    
    public String? FirstName { get; set; }

    public String? LastName { get; set; }

    public int Age { get; set; }

    public String? Gender { get; set; }

    public String? Rank { get; set; }

    public Boolean? SpecialSoldier { get; set; }

    public String? SoldierType { get; set; }

}