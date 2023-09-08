﻿// <auto-generated />
using System;
using Edu.Code.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Edu.Code.Database.Migrations
{
    [DbContext(typeof(EduCodeDbContext))]
    [Migration("20230908015413_RemoveCodeFromStudentDoubtTable")]
    partial class RemoveCodeFromStudentDoubtTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Edu.Code.Domain.Modules.Entities.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("module", "edu-code");
                });

            modelBuilder.Entity("Edu.Code.Domain.Modules.Entities.ModuleTopic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uuid")
                        .HasColumnName("module_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("module_topic", "edu-code");
                });

            modelBuilder.Entity("Edu.Code.Domain.Modules.Entities.TopicContent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uuid")
                        .HasColumnName("topic_id");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("topic_content", "edu-code");
                });

            modelBuilder.Entity("Edu.Code.Domain.Questions.Entities.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("Difficulty")
                        .HasColumnType("integer")
                        .HasColumnName("difficulty");

                    b.Property<Guid>("ListId")
                        .HasColumnType("uuid")
                        .HasColumnName("list_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.ToTable("question", "edu-code");
                });

            modelBuilder.Entity("Edu.Code.Domain.Questions.Entities.QuestionExample", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Input")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("input");

                    b.Property<string>("Output")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("output");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid")
                        .HasColumnName("question_id");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("question_example", "edu-code");
                });

            modelBuilder.Entity("Edu.Code.Domain.Questions.Entities.QuestionList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("question_list", "edu-code");
                });

            modelBuilder.Entity("Edu.Code.Domain.StudentsDoubts.Entities.StudentDoubt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("answer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Doubt")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("doubt");

                    b.HasKey("Id");

                    b.ToTable("student_doubt", "edu-code");
                });

            modelBuilder.Entity("Edu.Code.Domain.Modules.Entities.ModuleTopic", b =>
                {
                    b.HasOne("Edu.Code.Domain.Modules.Entities.Module", "Module")
                        .WithMany("Topics")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");
                });

            modelBuilder.Entity("Edu.Code.Domain.Modules.Entities.TopicContent", b =>
                {
                    b.HasOne("Edu.Code.Domain.Modules.Entities.ModuleTopic", "Topic")
                        .WithMany("Contents")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Edu.Code.Domain.Questions.Entities.Question", b =>
                {
                    b.HasOne("Edu.Code.Domain.Questions.Entities.QuestionList", "List")
                        .WithMany("Questions")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("List");
                });

            modelBuilder.Entity("Edu.Code.Domain.Questions.Entities.QuestionExample", b =>
                {
                    b.HasOne("Edu.Code.Domain.Questions.Entities.Question", "Question")
                        .WithMany("Examples")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Edu.Code.Domain.Modules.Entities.Module", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("Edu.Code.Domain.Modules.Entities.ModuleTopic", b =>
                {
                    b.Navigation("Contents");
                });

            modelBuilder.Entity("Edu.Code.Domain.Questions.Entities.Question", b =>
                {
                    b.Navigation("Examples");
                });

            modelBuilder.Entity("Edu.Code.Domain.Questions.Entities.QuestionList", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
