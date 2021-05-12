using Microsoft.EntityFrameworkCore.Migrations;

namespace SlutProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diamonds",
                columns: table => new
                {
                    DiamondId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageName = table.Column<string>(nullable: true),
                    OnSale = table.Column<bool>(nullable: false),
                    InStock = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diamonds", x => x.DiamondId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiamondId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    ShoppingCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Diamonds_DiamondId",
                        column: x => x.DiamondId,
                        principalTable: "Diamonds",
                        principalColumn: "DiamondId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Diamonds",
                columns: new[] { "DiamondId", "Description", "ImageName", "InStock", "Name", "OnSale", "Price" },
                values: new object[,]
                {
                    { 1, "Our famous diamond ring!", "pro01.jpg", true, "Cocktail Ring", true, 1200.95m },
                    { 2, "A summer classic!", "pro02.jpg", true, "Mourning Ring", false, 1800.95m },
                    { 3, "Blazing as fire", "pro03.jpg", true, "Cameo Ring", false, 1800.95m },
                    { 4, "Everlasting love", "pro04.jpg", true, "Eternity Ring", false, 1500.95m },
                    { 5, "A Christmas favorite", "pro05.jpg", true, "Puzzle Ring", false, 1300.95m },
                    { 6, "Pure daimond. Pure pleasure.", "pro06.jpg", true, "Rosary Ring", false, 1700.95m },
                    { 7, "My God, so elegent!", "pro07.jpg", false, "Purity Ring", false, 1500.95m },
                    { 8, "Happy holidays with this ring!", "pro08.jpg", true, "Birthstone Ring", true, 1200.95m },
                    { 9, "You'll love it!", "pro09.jpg", true, "Armour Ring", true, 1500.95m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_DiamondId",
                table: "ShoppingCartItems",
                column: "DiamondId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Diamonds");
        }
    }
}
