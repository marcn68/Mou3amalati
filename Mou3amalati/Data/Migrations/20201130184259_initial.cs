using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mou3amalati.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "birthDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "birthPlace",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "bloodTypeId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "civilRegisterNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "civilStatusId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fatherId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "genderId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "motherId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "originAddressId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "religionId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "residenceAddressId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "roleId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    state = table.Column<string>(nullable: true),
                    district = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    streetName = table.Column<string>(nullable: true),
                    buildingName = table.Column<string>(nullable: true),
                    details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BloodType",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CivilStatus",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilStatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    details = table.Column<string>(nullable: true),
                    price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Religion",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    religion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentRequest",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    citizenId = table.Column<int>(nullable: false),
                    userId = table.Column<string>(nullable: true),
                    assignedToId = table.Column<int>(nullable: false),
                    assignedToUserId = table.Column<string>(nullable: true),
                    documentId = table.Column<int>(nullable: false),
                    docsid = table.Column<int>(nullable: true),
                    requestDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentRequest", x => x.id);
                    table.ForeignKey(
                        name: "FK_DocumentRequest_AspNetUsers_assignedToUserId",
                        column: x => x.assignedToUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentRequest_Document_docsid",
                        column: x => x.docsid,
                        principalTable: "Document",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentRequest_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentRequestStatus",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    documentRequestId = table.Column<int>(nullable: false),
                    statusId = table.Column<int>(nullable: false),
                    assignedToId = table.Column<int>(nullable: false),
                    assignedToUserId = table.Column<string>(nullable: true),
                    statusDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentRequestStatus", x => x.id);
                    table.ForeignKey(
                        name: "FK_DocumentRequestStatus_AspNetUsers_assignedToUserId",
                        column: x => x.assignedToUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentRequestStatus_DocumentRequest_documentRequestId",
                        column: x => x.documentRequestId,
                        principalTable: "DocumentRequest",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentRequestStatus_Status_statusId",
                        column: x => x.statusId,
                        principalTable: "Status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_bloodTypeId",
                table: "AspNetUsers",
                column: "bloodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_civilStatusId",
                table: "AspNetUsers",
                column: "civilStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_genderId",
                table: "AspNetUsers",
                column: "genderId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_originAddressId",
                table: "AspNetUsers",
                column: "originAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_religionId",
                table: "AspNetUsers",
                column: "religionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_residenceAddressId",
                table: "AspNetUsers",
                column: "residenceAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_roleId",
                table: "AspNetUsers",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentRequest_assignedToUserId",
                table: "DocumentRequest",
                column: "assignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentRequest_docsid",
                table: "DocumentRequest",
                column: "docsid");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentRequest_userId",
                table: "DocumentRequest",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentRequestStatus_assignedToUserId",
                table: "DocumentRequestStatus",
                column: "assignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentRequestStatus_documentRequestId",
                table: "DocumentRequestStatus",
                column: "documentRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentRequestStatus_statusId",
                table: "DocumentRequestStatus",
                column: "statusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BloodType_bloodTypeId",
                table: "AspNetUsers",
                column: "bloodTypeId",
                principalTable: "BloodType",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CivilStatus_civilStatusId",
                table: "AspNetUsers",
                column: "civilStatusId",
                principalTable: "CivilStatus",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Gender_genderId",
                table: "AspNetUsers",
                column: "genderId",
                principalTable: "Gender",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Address_originAddressId",
                table: "AspNetUsers",
                column: "originAddressId",
                principalTable: "Address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Religion_religionId",
                table: "AspNetUsers",
                column: "religionId",
                principalTable: "Religion",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Address_residenceAddressId",
                table: "AspNetUsers",
                column: "residenceAddressId",
                principalTable: "Address",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_roleId",
                table: "AspNetUsers",
                column: "roleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BloodType_bloodTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CivilStatus_civilStatusId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Gender_genderId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Address_originAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Religion_religionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Address_residenceAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_roleId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "BloodType");

            migrationBuilder.DropTable(
                name: "CivilStatus");

            migrationBuilder.DropTable(
                name: "DocumentRequestStatus");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Religion");

            migrationBuilder.DropTable(
                name: "DocumentRequest");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_bloodTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_civilStatusId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_genderId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_originAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_religionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_residenceAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_roleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "birthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "birthPlace",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "bloodTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "civilRegisterNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "civilStatusId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "fatherId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "firstname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "genderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "motherId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "originAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "religionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "residenceAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "roleId",
                table: "AspNetUsers");
        }
    }
}
