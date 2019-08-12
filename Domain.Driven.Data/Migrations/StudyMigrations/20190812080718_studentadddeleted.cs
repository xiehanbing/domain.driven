using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Driven.Data.Migrations.StudyMigrations
{
    public partial class studentadddeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Student",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Student");
        }
    }
}
