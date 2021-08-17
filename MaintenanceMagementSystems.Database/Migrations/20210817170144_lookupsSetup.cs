using Microsoft.EntityFrameworkCore.Migrations;

namespace MaintenanceManagementSystem.Database.Migrations
{
    public partial class lookupsSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleType", "RoleNameAr", "RoleNameEn" },
                values: new object[] { "SystemAdmin", "مسؤول نظام", "System Admin" }
                );

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleType", "RoleNameAr", "RoleNameEn" },
                values: new object[] { "BuildingManager", "مسؤول مبنى", "Building Manager" }
                );

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleType", "RoleNameAr", "RoleNameEn" },
                values: new object[] { "MaintenanceManager", "مسؤول صيانة", "Maintenance Manager" }
                );

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleType", "RoleNameAr", "RoleNameEn" },
                values: new object[] { "MaintenanceWorker", "عامل صيانة", "Maintenance Worker" }
                );

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleType", "RoleNameAr", "RoleNameEn" },
                values: new object[] { "Beneficiary", "مستفيد", "Beneficiary" }
                );

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusTypeAr", "StatusTypeEn"},
                values: new object[] { "جديد", "New" }
                );

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusTypeAr", "StatusTypeEn" },
                values: new object[] { "قيد المراجعة", "Under Review" }
                );

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusTypeAr", "StatusTypeEn" },
                values: new object[] { "قيد الانتظار", "Pending" }
                );

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusTypeAr", "StatusTypeEn" },
                values: new object[] { "قيد الصيانة", "Fixing" }
                );

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusTypeAr", "StatusTypeEn" },
                values: new object[] { "مكتمل", "Completed" }
                );

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusTypeAr", "StatusTypeEn" },
                values: new object[] { "مرفوض", "Rejected" }
                );

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusTypeAr", "StatusTypeEn" },
                values: new object[] { "ملغى", "Canceled" }
                );

            migrationBuilder.InsertData(
                table: "MaintenanceTypes",
                columns: new[] { "MaintenanceTypeNameAr", "MaintenanceTypeNameEn" },
                values: new object[] { "مشكلة كهرباء", "Electricity Issue" }
                );

            migrationBuilder.InsertData(
                table: "MaintenanceTypes",
                columns: new[] { "MaintenanceTypeNameAr", "MaintenanceTypeNameEn" },
                values: new object[] { "مشكلة سباكة", "Plumbing Issue" }
                );

            migrationBuilder.InsertData(
                table: "MaintenanceTypes",
                columns: new[] { "MaintenanceTypeNameAr", "MaintenanceTypeNameEn" },
                values: new object[] { "مشكلة تدفئة/تكييف", "Heating/Air Conditioning Issue" }
                );

            migrationBuilder.InsertData(
                table: "MaintenanceTypes",
                columns: new[] { "MaintenanceTypeNameAr", "MaintenanceTypeNameEn" },
                values: new object[] { "مشكلة إصلاح", "Repair Issue" }
                );

            migrationBuilder.InsertData(
                table: "MaintenanceTypes",
                columns: new[] { "MaintenanceTypeNameAr", "MaintenanceTypeNameEn" },
                values: new object[] { "أخرى", "Other" }
                );

            migrationBuilder.InsertData(
                table: "CancelationReasons",
                columns: new[] { "ReasonTypeAr", "ReasonTypeEn" },
                values: new object[] { "لقد أرسلت شيئًا خاطئًا", "I submitted something wrong" }
                );

            migrationBuilder.InsertData(
                table: "CancelationReasons",
                columns: new[] { "ReasonTypeAr", "ReasonTypeEn" },
                values: new object[] { "لست بحاجة إلى صيانة بعد الآن", "I don't need maintenance anymore" }
                );

            migrationBuilder.InsertData(
                table: "CancelationReasons",
                columns: new[] { "ReasonTypeAr", "ReasonTypeEn" },
                values: new object[] { "لا يناسبني التاريخ والوقت", "The date and time don't suit me" }
                );

            migrationBuilder.InsertData(
                table: "CancelationReasons",
                columns: new[] { "ReasonTypeAr", "ReasonTypeEn" },
                values: new object[] { "أخرى", "Other" }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
