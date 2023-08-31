using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Genre", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Bames returns for one last mission to save the president from impending doom.", 2, "Bames Jond 2", 1970 },
                    { 2, "Wellsa was a failed cryogenic scientist, destined to unfreeze people that have been frozen.", 4, "Unfrozen", 2020 },
                    { 3, "Aliens are invading Earth and it's up to a group of unlikely heroes to stop them.", 4, "Space Invaders", 2019 },
                    { 4, "A group of explorers venture into the jungle searching for a lost city of gold.", 6, "Jungle Adventure", 2015 },
                    { 5, "A family moves into a new house only to find out that it is haunted.", 5, "Mystery of the Haunted House", 2010 },
                    { 6, "A lone warrior fights against the forces of evil.", 2, "The Last Warrior", 2005 },
                    { 7, "Friends go on a road trip and have a series of comedic adventures.", 1, "Road Trip", 2018 },
                    { 8, "A romantic story set in the city of love, Paris.", 3, "Love in Paris", 2016 },
                    { 9, "A team of treasure hunters go on an expedition to find a hidden treasure.", 6, "Treasure Hunt", 2022 },
                    { 10, "In a future where AI has taken over, a group of rebels fight to take back control.", 4, "Tech Apocalypse", 2030 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
