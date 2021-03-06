﻿// <auto-generated />
using DBContextSQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Model.Enum;
using System;

namespace DBContextSQLite.Migrations
{
    [DbContext(typeof(VeiculoContext))]
    partial class VeiculoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Model.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Chassi");

                    b.Property<string>("Cor");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<byte>("NPassageiros");

                    b.Property<int>("TipoVeiculo");

                    b.HasKey("Id");

                    b.ToTable("Veiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
