﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApplication.Database;

namespace ToDoApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211103124255_addAssignee")]
    partial class addAssignee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("ToDoApplication.Models.Entities.Assignee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<long?>("TodoTaskId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TodoTaskId")
                        .IsUnique();

                    b.ToTable("Assignees");
                });

            modelBuilder.Entity("ToDoApplication.Models.Entities.Todo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDone")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsUrgent")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("ToDoApplication.Models.Entities.Assignee", b =>
                {
                    b.HasOne("ToDoApplication.Models.Entities.Todo", "TodoTask")
                        .WithOne("Assignee")
                        .HasForeignKey("ToDoApplication.Models.Entities.Assignee", "TodoTaskId");

                    b.Navigation("TodoTask");
                });

            modelBuilder.Entity("ToDoApplication.Models.Entities.Todo", b =>
                {
                    b.Navigation("Assignee");
                });
#pragma warning restore 612, 618
        }
    }
}
