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
    [Migration("20221228004327_ManyToManyBetweenUserAndWorkspace")]
    partial class ManyToManyBetweenUserAndWorkspace
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            modelBuilder.Entity("Data.Entities.Collection", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Documentation")
                        .HasColumnType("text");

                    b.Property<bool?>("IsFavorite")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ShareLink")
                        .HasColumnType("text");

                    b.Property<Guid?>("WorkspaceId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WorkspaceId");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("Data.Entities.Folder", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CollectionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Documentation")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("Folder");
                });

            modelBuilder.Entity("Data.Entities.History", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Action")
                        .HasColumnType("integer");

                    b.Property<Guid?>("QueryId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("QueryId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("Data.Entities.Query", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("DefaultResponseWithLimit")
                        .HasColumnType("text");

                    b.Property<string>("Documentation")
                        .HasColumnType("text");

                    b.Property<Guid?>("FolderId")
                        .HasColumnType("uuid");

                    b.Property<double?>("LastExecuteTime")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("RawSql")
                        .HasColumnType("text");

                    b.Property<int?>("Size")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("Query");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<Guid>("WorkspaceId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Data.Entities.Workspace", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("DbConnectionString")
                        .HasColumnType("text");

                    b.Property<string>("DefaultConfigsForQueries")
                        .HasColumnType("text");

                    b.Property<string>("Documentation")
                        .HasColumnType("text");

                    b.Property<string>("EnvVariables")
                        .HasColumnType("text");

                    b.Property<string>("InviteLink")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int?>("UsersLimit")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Workspace");
                });

            modelBuilder.Entity("UserWorkspace", b =>
                {
                    b.Property<Guid>("CollaboratorsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorkspacesId")
                        .HasColumnType("uuid");

                    b.HasKey("CollaboratorsId", "WorkspacesId");

                    b.HasIndex("WorkspacesId");

                    b.ToTable("UserWorkspace");
                });

            modelBuilder.Entity("Data.Entities.Collection", b =>
                {
                    b.HasOne("Data.Entities.Workspace", "Workspace")
                        .WithMany("Collections")
                        .HasForeignKey("WorkspaceId");

                    b.Navigation("Workspace");
                });

            modelBuilder.Entity("Data.Entities.Folder", b =>
                {
                    b.HasOne("Data.Entities.Collection", "Collection")
                        .WithMany("Folders")
                        .HasForeignKey("CollectionId");

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("Data.Entities.History", b =>
                {
                    b.HasOne("Data.Entities.Query", "Query")
                        .WithMany()
                        .HasForeignKey("QueryId");

                    b.Navigation("Query");
                });

            modelBuilder.Entity("Data.Entities.Query", b =>
                {
                    b.HasOne("Data.Entities.Folder", "Folder")
                        .WithMany("Queries")
                        .HasForeignKey("FolderId");

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("UserWorkspace", b =>
                {
                    b.HasOne("Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("CollaboratorsId")
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
                });

            modelBuilder.Entity("Data.Entities.Folder", b =>
                {
                    b.Navigation("Queries");
                });

            modelBuilder.Entity("Data.Entities.Workspace", b =>
                {
                    b.Navigation("Collections");
                });
#pragma warning restore 612, 618
        }
    }
}