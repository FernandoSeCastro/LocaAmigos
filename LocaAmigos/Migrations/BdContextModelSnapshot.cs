﻿// <auto-generated />
using System;
using LocaAmigos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LocaAmigos.Migrations
{
    [DbContext(typeof(BdContext))]
    partial class BdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("LocaAmigos.Models.Jogos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("nome")
                        .HasColumnType("text");

                    b.Property<DateTime?>("remove")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("tipojogo")
                        .HasColumnType("text");

                    b.Property<DateTime?>("update")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.ToTable("jogos");
                });

            modelBuilder.Entity("LocaAmigos.Models.Movimentacoes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("Jogosid")
                        .HasColumnType("integer");

                    b.Property<int?>("Pessoaid")
                        .HasColumnType("integer");

                    b.Property<int?>("Usuarioid")
                        .HasColumnType("integer");

                    b.Property<bool>("ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fim")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("inicio")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("remove")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("update")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.HasIndex("Jogosid");

                    b.HasIndex("Pessoaid");

                    b.HasIndex("Usuarioid");

                    b.ToTable("movimentacoes");
                });

            modelBuilder.Entity("LocaAmigos.Models.Pessoa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("datanascimento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("nome")
                        .HasColumnType("text");

                    b.Property<string>("nomecompleto")
                        .HasColumnType("text");

                    b.Property<DateTime?>("remove")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("update")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.ToTable("pessoa");
                });

            modelBuilder.Entity("LocaAmigos.Models.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("Pessoaid")
                        .HasColumnType("integer");

                    b.Property<bool>("ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<DateTime?>("remove")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("roles")
                        .HasColumnType("text");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("update")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.HasIndex("Pessoaid");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("LocaAmigos.Models.Movimentacoes", b =>
                {
                    b.HasOne("LocaAmigos.Models.Jogos", "Jogos")
                        .WithMany()
                        .HasForeignKey("Jogosid");

                    b.HasOne("LocaAmigos.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("Pessoaid");

                    b.HasOne("LocaAmigos.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Usuarioid");

                    b.Navigation("Jogos");

                    b.Navigation("Pessoa");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LocaAmigos.Models.Usuario", b =>
                {
                    b.HasOne("LocaAmigos.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("Pessoaid");

                    b.Navigation("Pessoa");
                });
#pragma warning restore 612, 618
        }
    }
}
