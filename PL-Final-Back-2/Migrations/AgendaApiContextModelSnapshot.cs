﻿// <auto-generated />
using Agenda_Tup_Back.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgendaTupBack.Migrations
{
    [DbContext(typeof(AgendaApiContext))]
    partial class AgendaApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Agenda_Tup_Back.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Pedido");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = "Familia",
                            State = "Reunión familiar",
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            Date = "Amigos",
                            State = "Clases de Matemática a las 17:30hs",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Agenda_Tup_Back.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("state")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Producto");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "HP",
                            Category = "Computadora",
                            Description = "gagagagab",
                            ImageUrl = "url_de_la_imagen",
                            Name = "Computadora",
                            Price = 1515,
                            state = 0
                        },
                        new
                        {
                            Id = 2,
                            Brand = "HP",
                            Category = "Auriculares",
                            Description = "gagagagab",
                            ImageUrl = "url_de_la_imagen",
                            Name = "Auriculares",
                            Price = 1545,
                            state = 0
                        });
                });

            modelBuilder.Entity("Agenda_Tup_Back.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.Property<int>("state")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Email = "danaMolina@gmail.com",
                            Name = "Dana",
                            Password = "456def",
                            Rol = 1,
                            state = 0
                        },
                        new
                        {
                            Id = 1,
                            Email = "ericaGomez@gmail.com",
                            Name = "Erica",
                            Password = "123abc",
                            Rol = 0,
                            state = 0
                        });
                });

            modelBuilder.Entity("PedidoProducto", b =>
                {
                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("PedidoId", "ProductoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("PedidoProducto");
                });

            modelBuilder.Entity("Agenda_Tup_Back.Entities.Pedido", b =>
                {
                    b.HasOne("Agenda_Tup_Back.Entities.User", "User")
                        .WithMany("Pedido")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PedidoProducto", b =>
                {
                    b.HasOne("Agenda_Tup_Back.Entities.Pedido", null)
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agenda_Tup_Back.Entities.Producto", null)
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Agenda_Tup_Back.Entities.User", b =>
                {
                    b.Navigation("Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}
