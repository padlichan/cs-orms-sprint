﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ORMS;

#nullable disable

namespace ORMS.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20241214180554_AddDogsParks")]
    partial class AddDogsParks
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DogPark", b =>
                {
                    b.Property<int>("DogsVisitedId")
                        .HasColumnType("int");

                    b.Property<int>("ParksVisitedId")
                        .HasColumnType("int");

                    b.HasKey("DogsVisitedId", "ParksVisitedId");

                    b.HasIndex("ParksVisitedId");

                    b.ToTable("DogPark");
                });

            modelBuilder.Entity("ORMS.Dog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Loves")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dogs");
                });

            modelBuilder.Entity("ORMS.Park", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RatingOutOf10")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Parks");
                });

            modelBuilder.Entity("ORMS.Toy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DogId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Squeaks")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DogId");

                    b.ToTable("Toys");
                });

            modelBuilder.Entity("DogPark", b =>
                {
                    b.HasOne("ORMS.Dog", null)
                        .WithMany()
                        .HasForeignKey("DogsVisitedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ORMS.Park", null)
                        .WithMany()
                        .HasForeignKey("ParksVisitedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ORMS.Toy", b =>
                {
                    b.HasOne("ORMS.Dog", "Dog")
                        .WithMany("Toys")
                        .HasForeignKey("DogId");

                    b.Navigation("Dog");
                });

            modelBuilder.Entity("ORMS.Dog", b =>
                {
                    b.Navigation("Toys");
                });
#pragma warning restore 612, 618
        }
    }
}
