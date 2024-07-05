using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Runner.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiskIngridients",
                columns: table => new
                {
                    DiskId = table.Column<int>(type: "int", nullable: false),
                    IngridientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiskIngridients", x => new { x.DiskId, x.IngridientId });
                    table.ForeignKey(
                        name: "FK_DiskIngridients_Dish_DiskId",
                        column: x => x.DiskId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiskIngridients_Ingredient_IngridientId",
                        column: x => x.IngridientId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dish",
                columns: new[] { "Id", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "https://cdn.shopify.com/s/files/1/0205/9582/articles/20220211142347-margherita-9920_ba86be55-674e-4f35-8094-2067ab41a671.jpg?crop=center&height=915&v=1644590192&width=1200", "Margheritta", 7.5 });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Tomato Sauce" });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Mozzarella" });

            migrationBuilder.InsertData(
                table: "DiskIngridients",
                columns: new[] { "DiskId", "IngridientId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "DiskIngridients",
                columns: new[] { "DiskId", "IngridientId" },
                values: new object[] { 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_DiskIngridients_IngridientId",
                table: "DiskIngridients",
                column: "IngridientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiskIngridients");

            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropTable(
                name: "Ingredient");
        }
    }
}
