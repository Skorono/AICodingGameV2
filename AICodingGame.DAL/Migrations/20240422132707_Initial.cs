using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AICodingGame.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BattleStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Robots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    ProjectPath = table.Column<string>(type: "text", nullable: false),
                    LastUpdated = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robots", x => x.Id);
                    table.UniqueConstraint("AK_Robots_ProjectPath", x => x.ProjectPath);
                });

            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battles_BattleStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "BattleStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            
            migrationBuilder.CreateTable(
                name: "BattleMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BattleId = table.Column<int>(type: "integer", nullable: false),
                    RobotId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleMembers_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleMembers_Robots_RobotId",
                        column: x => x.RobotId,
                        principalTable: "Robots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BattleStatistics",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    AccuracyPercent = table.Column<float>(type: "real", nullable: false),
                    Kills = table.Column<int>(type: "integer", nullable: false),
                    LifeTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleStatistics", x => new { x.MemberId });
                    table.ForeignKey(
                        name: "FK_BattleStatistics_BattleMembers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "BattleMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BattleStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Завершён" },
                    { 2, "Идёт" },
                    { 3, "Удалён" },
                    { 4, "Прерван" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleMembers_BattleId",
                table: "BattleMembers",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleMembers_RobotId",
                table: "BattleMembers",
                column: "RobotId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleStatistics_MemberId",
                table: "BattleStatistics",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Battles_StatusId",
                table: "Battles",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleStatistics");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "BattleMembers");

            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropTable(
                name: "Robots");

            migrationBuilder.DropTable(
                name: "BattleStatuses");
        }
    }
}
