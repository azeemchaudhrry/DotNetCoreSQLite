using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNetCoreSQLite.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quote_types",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    text = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quote_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(maxLength: 2000, nullable: true),
                    author_id = table.Column<int>(nullable: false),
                    quote_type_id = table.Column<int>(nullable: false),
                    authorid = table.Column<int>(nullable: true),
                    quote_typeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quotes_authors_authorid",
                        column: x => x.authorid,
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_quotes_quote_types_quote_typeid",
                        column: x => x.quote_typeid,
                        principalTable: "quote_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_quotes_authorid",
                table: "quotes",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "IX_quotes_quote_typeid",
                table: "quotes",
                column: "quote_typeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "quotes");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "quote_types");
        }
    }
}
