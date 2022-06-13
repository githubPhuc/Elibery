using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elibery.Migrations
{
    public partial class AddVaitro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "VaiTro",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ThongBao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiThongBao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idQuyen = table.Column<int>(type: "int", nullable: true),
                    phanQuyenId = table.Column<int>(type: "int", nullable: true),
                    ChuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongBao_PhanQuyen_phanQuyenId",
                        column: x => x.phanQuyenId,
                        principalTable: "PhanQuyen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ThuVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTruongHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTruongHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HieuTruong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenHeThong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiTruyCap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgonNguXacDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NienKhoaMacDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuVien", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThongBao_phanQuyenId",
                table: "ThongBao",
                column: "phanQuyenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThongBao");

            migrationBuilder.DropTable(
                name: "ThuVien");

            migrationBuilder.DropColumn(
                name: "NgayCapNhatCuoi",
                table: "VaiTro");
        }
    }
}
