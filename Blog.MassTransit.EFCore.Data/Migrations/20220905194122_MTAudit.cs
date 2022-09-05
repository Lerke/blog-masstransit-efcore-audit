using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Blog.MassTransit.EFCore.Data.Migrations
{
    public partial class MTAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MTAuditEvents",
                columns: table => new
                {
                    AuditRecordId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: true),
                    ConversationId = table.Column<Guid>(type: "uuid", nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uuid", nullable: true),
                    InitiatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: true),
                    SentTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SourceAddress = table.Column<string>(type: "text", nullable: true),
                    DestinationAddress = table.Column<string>(type: "text", nullable: true),
                    ResponseAddress = table.Column<string>(type: "text", nullable: true),
                    FaultAddress = table.Column<string>(type: "text", nullable: true),
                    InputAddress = table.Column<string>(type: "text", nullable: true),
                    ContextType = table.Column<string>(type: "text", nullable: true),
                    MessageType = table.Column<string>(type: "text", nullable: true),
                    Custom = table.Column<string>(type: "text", nullable: true),
                    Headers = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTAuditEvents", x => x.AuditRecordId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MTAuditEvents");
        }
    }
}
