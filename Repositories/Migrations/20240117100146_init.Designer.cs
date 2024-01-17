﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories;

#nullable disable

namespace Repositories.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240117100146_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Ma grande",
                            Name = "Lilyah"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Ma petite",
                            Name = "Kezyah"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Papa",
                            Name = "Wakko"
                        });
                });

            modelBuilder.Entity("Entities.Commande", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Commandes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            Description = "Clt1 cmd1"
                        },
                        new
                        {
                            Id = 2,
                            ClientId = 1,
                            Description = "Clt1 cmd2"
                        },
                        new
                        {
                            Id = 3,
                            ClientId = 2,
                            Description = "Clt2 cmd1"
                        },
                        new
                        {
                            Id = 4,
                            ClientId = 3,
                            Description = "Clt3 cmd1"
                        });
                });

            modelBuilder.Entity("Entities.Commande", b =>
                {
                    b.HasOne("Entities.Client", "Client")
                        .WithMany("Commandes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Entities.Client", b =>
                {
                    b.Navigation("Commandes");
                });
#pragma warning restore 612, 618
        }
    }
}