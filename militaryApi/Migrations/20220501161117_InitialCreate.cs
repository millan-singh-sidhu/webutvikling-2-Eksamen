using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace militaryApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Soldier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SoldierImage = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Rank = table.Column<string>(type: "TEXT", nullable: true),
                    SpecialSoldier = table.Column<bool>(type: "INTEGER", nullable: true),
                    SoldierType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soldier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeaponImage = table.Column<string>(type: "TEXT", nullable: true),
                    WeaponName = table.Column<string>(type: "TEXT", nullable: true),
                    WeaponType = table.Column<string>(type: "TEXT", nullable: true),
                    AmmoCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    AmmoType = table.Column<string>(type: "TEXT", nullable: true),
                    Automatic = table.Column<bool>(type: "INTEGER", nullable: true),
                    SemiAutomatic = table.Column<bool>(type: "INTEGER", nullable: true),
                    SingelFire = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Soldier");

            migrationBuilder.DropTable(
                name: "Weapon");
        }
    }
}
