﻿// <auto-generated />
using System;
using Agenda_Tup_Back.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PLFinalBack2.Migrations
{
    [DbContext(typeof(AgendaApiContext))]
    partial class AgendaApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("Agenda_Tup_Back.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

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
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<int>("state")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("Producto");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "HP",
                            Category = "Computadora",
                            Description = "gagagagab",
                            ImageUrl = "https://i.pinimg.com/564x/5a/62/1e/5a621e11a8cc9fd152d6805cd5f67724.jpg",
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
                            ImageUrl = "https://i.pinimg.com/564x/f2/99/42/f29942dc13ba97a29d27ff47f83ec36e.jpg",
                            Name = "Auriculares",
                            Price = 1545,
                            state = 0
                        });
                });

            modelBuilder.Entity("Agenda_Tup_Back.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Rol")
                        .HasColumnType("INTEGER");

                    b.Property<int>("state")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ericaGomez@gmail.com",
                            Name = "Erica",
                            Password = "123abc",
                            Rol = 0,
                            state = 0
                        },
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
                            Id = 3,
                            Email = "anaMolina@gmail.com",
                            Name = "Ana",
                            Password = "456def",
                            Rol = 2,
                            state = 0
                        });
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

            modelBuilder.Entity("Agenda_Tup_Back.Entities.Producto", b =>
                {
                    b.HasOne("Agenda_Tup_Back.Entities.Pedido", "Pedido")
                        .WithMany("Producto")
                        .HasForeignKey("PedidoId");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Agenda_Tup_Back.Entities.Pedido", b =>
                {
                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Agenda_Tup_Back.Entities.User", b =>
                {
                    b.Navigation("Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}
