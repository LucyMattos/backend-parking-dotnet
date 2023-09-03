﻿// <auto-generated />
using System;
using EstacionamentoAPI.Repository.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EstacionamentoAPI.Repository.Migrations
{
    [DbContext(typeof(EstacionamentoContext))]
    [Migration("20230903211448_ChangeColumnDataSaida")]
    partial class ChangeColumnDataSaida
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EstacionamentoAPI.Domain.Entidades.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<DateTimeOffset?>("DataCriacao")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<bool>("Excluido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTimeOffset?>("ExcluidoEm")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<DateTimeOffset?>("UltimaAtualizacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("VagasParaCarros")
                        .HasColumnType("INT");

                    b.Property<int>("VagasParaMotos")
                        .HasColumnType("INT");

                    b.HasKey("Id")
                        .HasName("PK_Empresas");

                    b.ToTable("Empresas", (string)null);
                });

            modelBuilder.Entity("EstacionamentoAPI.Domain.Entidades.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTimeOffset?>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("DataEntrada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime?>("DataSaida")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("INT");

                    b.Property<bool>("Excluido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTimeOffset?>("ExcluidoEm")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<int>("Tipo")
                        .HasColumnType("INT");

                    b.Property<DateTimeOffset?>("UltimaAtualizacao")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id")
                        .HasName("PK_Veiculos");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Veiculos", (string)null);
                });

            modelBuilder.Entity("EstacionamentoAPI.Domain.Entidades.Veiculo", b =>
                {
                    b.HasOne("EstacionamentoAPI.Domain.Entidades.Empresa", "Empresa")
                        .WithMany("Veiculos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("EstacionamentoAPI.Domain.Entidades.Empresa", b =>
                {
                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
