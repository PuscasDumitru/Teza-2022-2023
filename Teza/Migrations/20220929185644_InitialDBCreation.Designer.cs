﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Teza.Migrations
{
    [DbContext(typeof(RepositoryDbContext))]
    [Migration("20220929185644_InitialDBCreation")]
    partial class InitialDBCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Data.Entities.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("boolean");

                    b.Property<string>("ShareLink")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("Data.Entities.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CollectionId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("QueryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.HasIndex("QueryId");

                    b.ToTable("Folder");
                });

            modelBuilder.Entity("Data.Entities.History", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("Action")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("History");
                });

            modelBuilder.Entity("Data.Entities.Query", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("DefaultResponseWithLimit")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<double>("LastExecuteTime")
                        .HasColumnType("double precision");

                    b.Property<string>("RawSql")
                        .HasColumnType("text");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Query");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("HashPassword")
                        .HasColumnType("text");

                    b.Property<int?>("HistoryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HistoryId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Data.Entities.Workspace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CollectionId")
                        .HasColumnType("integer");

                    b.Property<string>("DbConnectionString")
                        .HasColumnType("text");

                    b.Property<string>("DefaultConfigsForQueries")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("EnvVariables")
                        .HasColumnType("text");

                    b.Property<string>("InviteLink")
                        .HasColumnType("text");

                    b.Property<int>("UsersLimit")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("Workspace");
                });

            modelBuilder.Entity("UserWorkspace", b =>
                {
                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkspacesId")
                        .HasColumnType("integer");

                    b.HasKey("UsersId", "WorkspacesId");

                    b.HasIndex("WorkspacesId");

                    b.ToTable("UserWorkspace");
                });

            modelBuilder.Entity("Data.Entities.Folder", b =>
                {
                    b.HasOne("Data.Entities.Collection", null)
                        .WithMany("Folders")
                        .HasForeignKey("CollectionId");

                    b.HasOne("Data.Entities.Query", null)
                        .WithMany("Folders")
                        .HasForeignKey("QueryId");
                });

            modelBuilder.Entity("Data.Entities.History", b =>
                {
                    b.HasOne("Data.Entities.Query", "Query")
                        .WithOne("History")
                        .HasForeignKey("Data.Entities.History", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Query");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.HasOne("Data.Entities.History", "History")
                        .WithMany()
                        .HasForeignKey("HistoryId");

                    b.Navigation("History");
                });

            modelBuilder.Entity("Data.Entities.Workspace", b =>
                {
                    b.HasOne("Data.Entities.Collection", null)
                        .WithMany("Workspaces")
                        .HasForeignKey("CollectionId");
                });

            modelBuilder.Entity("UserWorkspace", b =>
                {
                    b.HasOne("Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Workspace", null)
                        .WithMany()
                        .HasForeignKey("WorkspacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.Collection", b =>
                {
                    b.Navigation("Folders");

                    b.Navigation("Workspaces");
                });

            modelBuilder.Entity("Data.Entities.Query", b =>
                {
                    b.Navigation("Folders");

                    b.Navigation("History");
                });
#pragma warning restore 612, 618
        }
    }
}