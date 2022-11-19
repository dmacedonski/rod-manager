using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RodManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Number = table.Column<string>(type: "TEXT", nullable: false),
                    AreaSize = table.Column<decimal>(type: "TEXT", nullable: false),
                    HasFinalDistributionBox = table.Column<bool>(type: "INTEGER", nullable: false),
                    FinalDistributionBoxNumber = table.Column<string>(type: "TEXT", nullable: true),
                    MasterBoxNumber = table.Column<string>(type: "TEXT", nullable: true),
                    ElectricityMeterNumber = table.Column<string>(type: "TEXT", nullable: true),
                    WaterMeterNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    GivenName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FamilyName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Privilege = table.Column<int>(type: "INTEGER", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AllotmentFarmers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GivenName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FamilyName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CorrespondenceAddress = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Pesel = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    JoiningAllotmentAssociationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EmailAddressForInvitation = table.Column<string>(type: "TEXT", nullable: true),
                    RodoAgreement = table.Column<bool>(type: "INTEGER", nullable: false),
                    FeesPublicationAgreement = table.Column<bool>(type: "INTEGER", nullable: false),
                    FinalDistributionBoxAccessAgreement = table.Column<bool>(type: "INTEGER", nullable: false),
                    PlotId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllotmentFarmers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllotmentFarmers_Plots_PlotId",
                        column: x => x.PlotId,
                        principalTable: "Plots",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllotmentFarmers_PlotId",
                table: "AllotmentFarmers",
                column: "PlotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllotmentFarmers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Plots");
        }
    }
}
