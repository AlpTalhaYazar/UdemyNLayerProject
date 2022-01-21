using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_feature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_feature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_feature_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pens", null });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Books", null });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Notebooks", null });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 1, 15, 20, 20, 25, 562, DateTimeKind.Local).AddTicks(8175), "Pen 1", 100m, 20, null },
                    { 2, 1, new DateTime(2022, 1, 15, 20, 20, 25, 562, DateTimeKind.Local).AddTicks(8186), "Pen 2", 200m, 30, null },
                    { 3, 1, new DateTime(2022, 1, 15, 20, 20, 25, 562, DateTimeKind.Local).AddTicks(8188), "Pen 3", 600m, 60, null },
                    { 4, 2, new DateTime(2022, 1, 15, 20, 20, 25, 562, DateTimeKind.Local).AddTicks(8189), "Book 1", 250m, 25, null },
                    { 5, 2, new DateTime(2022, 1, 15, 20, 20, 25, 562, DateTimeKind.Local).AddTicks(8190), "Book 2", 400m, 40, null },
                    { 6, 3, new DateTime(2022, 1, 15, 20, 20, 25, 562, DateTimeKind.Local).AddTicks(8191), "Notebook 1", 160m, 26, null },
                    { 7, 3, new DateTime(2022, 1, 15, 20, 20, 25, 562, DateTimeKind.Local).AddTicks(8192), "Notebook 2", 350m, 35, null }
                });

            migrationBuilder.InsertData(
                table: "product_feature",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Width" },
                values: new object[,]
                {
                    { 1, "Red", 15, 1, 10 },
                    { 2, "Green", 25, 2, 5 },
                    { 3, "Turquoise", 41, 3, 13 },
                    { 4, "Gray", 45, 4, 4 },
                    { 5, "Cyan", 5, 5, 10 },
                    { 6, "Blue", 20, 6, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_CategoryId",
                table: "product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_product_feature_ProductId",
                table: "product_feature",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_feature");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
