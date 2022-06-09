using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elibery.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoMon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBoMon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoMon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiLopHoc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiLopHoc", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PhanQuyen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loaiId = table.Column<int>(type: "int", nullable: false),
                    loaiLopHocid = table.Column<int>(type: "int", nullable: false),
                    NienKhoa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LopHoc_LoaiLopHoc_loaiLopHocid",
                        column: x => x.loaiLopHocid,
                        principalTable: "LoaiLopHoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaiTro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idQuyen = table.Column<int>(type: "int", nullable: false),
                    ThongBao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phanQuyenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaiTro_PhanQuyen_phanQuyenId",
                        column: x => x.phanQuyenId,
                        principalTable: "PhanQuyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoMonId = table.Column<int>(type: "int", nullable: false),
                    idLopHoc = table.Column<int>(type: "int", nullable: false),
                    lopHocIdId = table.Column<int>(type: "int", nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonHoc_BoMon_BoMonId",
                        column: x => x.BoMonId,
                        principalTable: "BoMon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonHoc_LopHoc_lopHocIdId",
                        column: x => x.lopHocIdId,
                        principalTable: "LopHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VaiTroId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_VaiTro_VaiTroId",
                        column: x => x.VaiTroId,
                        principalTable: "VaiTro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaiLieu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tentailieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    monhocId = table.Column<int>(type: "int", nullable: true),
                    PheDuyet = table.Column<bool>(type: "bit", nullable: false),
                    NgayGuiPheDuyet = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiLieu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiLieu_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaiLieu_MonHoc_monhocId",
                        column: x => x.monhocId,
                        principalTable: "MonHoc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiChinhSua = table.Column<int>(type: "int", nullable: false),
                    NgaySuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KichThuoc = table.Column<int>(type: "int", nullable: false),
                    idTaiLieu = table.Column<int>(type: "int", nullable: false),
                    TaiLieuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tep_TaiLieu_TaiLieuId",
                        column: x => x.TaiLieuId,
                        principalTable: "TaiLieu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaiGiang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenBaiGiang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonHocId = table.Column<int>(type: "int", nullable: false),
                    NguoiChinhSua = table.Column<int>(type: "int", nullable: false),
                    NguoiChinhSuaCuoi = table.Column<int>(type: "int", nullable: false),
                    PheDuyet = table.Column<bool>(type: "bit", nullable: false),
                    idTep = table.Column<int>(type: "int", nullable: false),
                    tepId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiGiang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaiGiang_MonHoc_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaiGiang_Tep_tepId",
                        column: x => x.tepId,
                        principalTable: "Tep",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeThi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tendethi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idMonHoc = table.Column<int>(type: "int", nullable: false),
                    monHocId = table.Column<int>(type: "int", nullable: true),
                    HinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiLuong = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false),
                    NguoiPheDuyet = table.Column<int>(type: "int", nullable: false),
                    PheDuyet = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TepId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LopHocId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeThi_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeThi_LopHoc_LopHocId",
                        column: x => x.LopHocId,
                        principalTable: "LopHoc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeThi_MonHoc_monHocId",
                        column: x => x.monHocId,
                        principalTable: "MonHoc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeThi_Tep_TepId",
                        column: x => x.TepId,
                        principalTable: "Tep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cauhoi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDeThi = table.Column<int>(type: "int", nullable: false),
                    deThiId = table.Column<int>(type: "int", nullable: true),
                    cauHoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dokho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cauhoi", x => x.id);
                    table.ForeignKey(
                        name: "FK_cauhoi_DeThi_deThiId",
                        column: x => x.deThiId,
                        principalTable: "DeThi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "dapan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dapAn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDapan = table.Column<bool>(type: "bit", nullable: false),
                    idCauhoi = table.Column<int>(type: "int", nullable: false),
                    cauhoiid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dapan", x => x.id);
                    table.ForeignKey(
                        name: "FK_dapan_cauhoi_cauhoiid",
                        column: x => x.cauhoiid,
                        principalTable: "cauhoi",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_VaiTroId",
                table: "AspNetUsers",
                column: "VaiTroId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BaiGiang_MonHocId",
                table: "BaiGiang",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_BaiGiang_tepId",
                table: "BaiGiang",
                column: "tepId");

            migrationBuilder.CreateIndex(
                name: "IX_cauhoi_deThiId",
                table: "cauhoi",
                column: "deThiId");

            migrationBuilder.CreateIndex(
                name: "IX_dapan_cauhoiid",
                table: "dapan",
                column: "cauhoiid");

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_ApplicationUserId",
                table: "DeThi",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_LopHocId",
                table: "DeThi",
                column: "LopHocId");

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_monHocId",
                table: "DeThi",
                column: "monHocId");

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_TepId",
                table: "DeThi",
                column: "TepId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_loaiLopHocid",
                table: "LopHoc",
                column: "loaiLopHocid");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_BoMonId",
                table: "MonHoc",
                column: "BoMonId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_lopHocIdId",
                table: "MonHoc",
                column: "lopHocIdId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_ApplicationUserId",
                table: "TaiLieu",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_monhocId",
                table: "TaiLieu",
                column: "monhocId");

            migrationBuilder.CreateIndex(
                name: "IX_Tep_TaiLieuId",
                table: "Tep",
                column: "TaiLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_VaiTro_phanQuyenId",
                table: "VaiTro",
                column: "phanQuyenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BaiGiang");

            migrationBuilder.DropTable(
                name: "dapan");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "cauhoi");

            migrationBuilder.DropTable(
                name: "DeThi");

            migrationBuilder.DropTable(
                name: "Tep");

            migrationBuilder.DropTable(
                name: "TaiLieu");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "VaiTro");

            migrationBuilder.DropTable(
                name: "BoMon");

            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropTable(
                name: "PhanQuyen");

            migrationBuilder.DropTable(
                name: "LoaiLopHoc");
        }
    }
}
