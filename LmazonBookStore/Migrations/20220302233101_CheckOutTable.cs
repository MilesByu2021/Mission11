using Microsoft.EntityFrameworkCore.Migrations;

namespace LmazonBookStore.Migrations
{
    public partial class CheckOutTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckOut",
                columns: table => new
                {
                    CheckoutId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: false),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOut", x => x.CheckoutId);
                });

            migrationBuilder.CreateTable(
                name: "BasketLineItem",
                columns: table => new
                {
                    LineID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BooksBookId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    CheckoutId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketLineItem", x => x.LineID);
                    table.ForeignKey(
                        name: "FK_BasketLineItem_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasketLineItem_CheckOut_CheckoutId",
                        column: x => x.CheckoutId,
                        principalTable: "CheckOut",
                        principalColumn: "CheckoutId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketLineItem_BooksBookId",
                table: "BasketLineItem",
                column: "BooksBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketLineItem_CheckoutId",
                table: "BasketLineItem",
                column: "CheckoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketLineItem");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "CheckOut");
        }
    }
}
