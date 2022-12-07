﻿// <auto-generated />
using System;
using EFDataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFDataLayer.Migrations
{
    [DbContext(typeof(QuizContext))]
    partial class QuizContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFDataLayer.Models.AnswerEF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int?>("QuestionEFId")
                        .HasColumnType("int");

                    b.Property<string>("QuestionEFSentence")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Sentence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionEFId", "QuestionEFSentence");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("EFDataLayer.Models.GameEF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId", "PlayerName");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("EFDataLayer.Models.PlayerEF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id", "Name");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("EFDataLayer.Models.QuestionEF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Sentence")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("GameEFId")
                        .HasColumnType("int");

                    b.HasKey("Id", "Sentence");

                    b.HasIndex("GameEFId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("EFDataLayer.Models.AnswerEF", b =>
                {
                    b.HasOne("EFDataLayer.Models.QuestionEF", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionEFId", "QuestionEFSentence");
                });

            modelBuilder.Entity("EFDataLayer.Models.GameEF", b =>
                {
                    b.HasOne("EFDataLayer.Models.PlayerEF", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId", "PlayerName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("EFDataLayer.Models.QuestionEF", b =>
                {
                    b.HasOne("EFDataLayer.Models.GameEF", null)
                        .WithMany("Questions")
                        .HasForeignKey("GameEFId");
                });

            modelBuilder.Entity("EFDataLayer.Models.GameEF", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("EFDataLayer.Models.QuestionEF", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
