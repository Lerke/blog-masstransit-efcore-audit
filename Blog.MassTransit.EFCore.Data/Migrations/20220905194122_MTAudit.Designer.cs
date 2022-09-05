﻿// <auto-generated />
using System;
using Blog.MassTransit.EFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Blog.MassTransit.EFCore.Data.Migrations
{
    [DbContext(typeof(AuditTestContext))]
    [Migration("20220905194122_MTAudit")]
    partial class MTAudit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.Audit.AuditRecord", b =>
                {
                    b.Property<int>("AuditRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AuditRecordId"));

                    b.Property<string>("ContextType")
                        .HasColumnType("text");

                    b.Property<Guid?>("ConversationId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CorrelationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Custom")
                        .HasColumnType("text");

                    b.Property<string>("DestinationAddress")
                        .HasColumnType("text");

                    b.Property<string>("FaultAddress")
                        .HasColumnType("text");

                    b.Property<string>("Headers")
                        .HasColumnType("text");

                    b.Property<Guid?>("InitiatorId")
                        .HasColumnType("uuid");

                    b.Property<string>("InputAddress")
                        .HasColumnType("text");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<Guid?>("MessageId")
                        .HasColumnType("uuid");

                    b.Property<string>("MessageType")
                        .HasColumnType("text");

                    b.Property<Guid?>("RequestId")
                        .HasColumnType("uuid");

                    b.Property<string>("ResponseAddress")
                        .HasColumnType("text");

                    b.Property<DateTime?>("SentTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SourceAddress")
                        .HasColumnType("text");

                    b.HasKey("AuditRecordId");

                    b.ToTable("MTAuditEvents", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
