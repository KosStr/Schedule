using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Schedule.Database.Migrations
{
    public partial class InitialScheduleRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Faculty = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CreatedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModifiedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DueDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Priority = table.Column<byte>(type: "TINYINT", nullable: false, defaultValue: (byte)1),
                    Type = table.Column<byte>(type: "TINYINT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CreatedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModifiedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CreatedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModifiedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Role = table.Column<byte>(type: "TINYINT", nullable: false, defaultValue: (byte)1),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailTokenLifetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GroupId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CreatedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModifiedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 5, 1, 14, 37, 6, 363, DateTimeKind.Utc).AddTicks(2769)),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    TeacherId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CreatedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModifiedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: true),
                    SubjectId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    TeacherId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    GroupId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CreatedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModifiedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrganizerId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CreatedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModifiedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Users_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 5, 1, 14, 37, 6, 397, DateTimeKind.Utc).AddTicks(3513)),
                    StudentId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    SubjectId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CreatedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModifiedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSubjects",
                columns: table => new
                {
                    TeacherId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    SubjectId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubjects", x => new { x.SubjectId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    NotificationId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    UsertId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => new { x.UsertId, x.NotificationId });
                    table.ForeignKey(
                        name: "FK_UserNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Users_UsertId",
                        column: x => x.UsertId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentGroups",
                columns: table => new
                {
                    AppointmentId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    GroupId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentGroups", x => new { x.GroupId, x.AppointmentId });
                    table.ForeignKey(
                        name: "FK_AppointmentGroups_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    AppointmentId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CreatedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModifiedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SenderId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    ChatId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CreatedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModifiedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserChats",
                columns: table => new
                {
                    UserId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    ChatId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChats", x => new { x.UserId, x.ChatId });
                    table.ForeignKey(
                        name: "FK_UserChats_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChats_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OwnerId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    GradeId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true),
                    AssignmentId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CreatedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModifiedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attachments_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachments_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignmentId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    AttachmentId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    UploaderId = table.Column<byte[]>(type: "VARBINARY(16)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CreatedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModifiedBy = table.Column<byte[]>(type: "VARBINARY(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Files_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Files_Users_UploaderId",
                        column: x => x.UploaderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentGroups_AppointmentId",
                table: "AppointmentGroups",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SubjectId",
                table: "Appointments",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TeacherId",
                table: "Appointments",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_GroupId",
                table: "Assignments",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_SubjectId",
                table: "Assignments",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TeacherId",
                table: "Assignments",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_AssignmentId",
                table: "Attachments",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_GradeId",
                table: "Attachments",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_OwnerId",
                table: "Attachments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_OrganizerId",
                table: "Chats",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_AssignmentId",
                table: "Files",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_AttachmentId",
                table: "Files",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UploaderId",
                table: "Files",
                column: "UploaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectId",
                table: "Grades",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Token",
                table: "RefreshTokens",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AppointmentId",
                table: "Tasks",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_TeacherId",
                table: "TeacherSubjects",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChats_ChatId",
                table: "UserChats",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_NotificationId",
                table: "UserNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentGroups");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TeacherSubjects");

            migrationBuilder.DropTable(
                name: "UserChats");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
