using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.Domain.Migrations
{
    public partial class UpdateGlossaryItemEntityAddHtmlContentParameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HtmlContent",
                table: "GlossaryItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HtmlContent",
                table: "GlossaryItems");
        }
    }
}
