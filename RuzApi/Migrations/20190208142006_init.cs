using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RuzApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Lessons",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        Auditorium = table.Column<string>(nullable: true),
            //        NumLesson = table.Column<int>(nullable: false),
            //        Date = table.Column<string>(nullable: true),
            //        Name = table.Column<string>(nullable: true),
            //        Type = table.Column<string>(nullable: true),
            //        Lecturer = table.Column<string>(nullable: true),
            //        Status = table.Column<string>(nullable: true),
            //        Email = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Lessons", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lessons");
        }
    }
}
