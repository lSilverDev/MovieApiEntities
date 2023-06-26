﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using moviesAPI___Entities.Data;

#nullable disable

namespace moviesAPI___Entities.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20230626181351_addingNewColumn")]
    partial class addingNewColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("moviesAPI___Entities.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("PublicPlace")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("moviesAPI___Entities.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("moviesAPI___Entities.Models.MovieTheater", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("MovieTheaters");
                });

            modelBuilder.Entity("moviesAPI___Entities.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int?>("MovieTheaterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("MovieTheaterId");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("moviesAPI___Entities.Models.MovieTheater", b =>
                {
                    b.HasOne("moviesAPI___Entities.Models.Address", "Address")
                        .WithOne("MovieTheater")
                        .HasForeignKey("moviesAPI___Entities.Models.MovieTheater", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("moviesAPI___Entities.Models.Session", b =>
                {
                    b.HasOne("moviesAPI___Entities.Models.Movie", "Movie")
                        .WithMany("Sessions")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("moviesAPI___Entities.Models.MovieTheater", "MovieTheater")
                        .WithMany("Sessions")
                        .HasForeignKey("MovieTheaterId");

                    b.Navigation("Movie");

                    b.Navigation("MovieTheater");
                });

            modelBuilder.Entity("moviesAPI___Entities.Models.Address", b =>
                {
                    b.Navigation("MovieTheater")
                        .IsRequired();
                });

            modelBuilder.Entity("moviesAPI___Entities.Models.Movie", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("moviesAPI___Entities.Models.MovieTheater", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
