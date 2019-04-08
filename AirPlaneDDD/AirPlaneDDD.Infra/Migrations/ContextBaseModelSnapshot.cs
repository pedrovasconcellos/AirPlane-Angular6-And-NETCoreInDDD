﻿// <auto-generated />
using System;
using AirPlaneDDD.Infra.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirPlaneDDD.Infra.Migrations
{
    [DbContext(typeof(ContextBase))]
    partial class ContextBaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirPlaneDDD.Domain.Entities.AirPlane", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreationDate");

                    b.Property<Guid>("ModelId");

                    b.Property<int>("NumberOfPassengers");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("AirPlane");

                    b.HasData(
                        new { Id = new Guid("b413cfc0-f53a-4765-9430-3912efcd79cb"), Code = "1", CreationDate = new DateTime(2019, 4, 8, 4, 35, 59, 392, DateTimeKind.Local), ModelId = new Guid("7f430a38-a6b2-4a8f-96d5-801725dfdfc1"), NumberOfPassengers = 111 },
                        new { Id = new Guid("a714554f-f363-42f1-b41a-81ee85186622"), Code = "3B", CreationDate = new DateTime(2019, 4, 8, 4, 35, 59, 394, DateTimeKind.Local), ModelId = new Guid("7f430a38-a6b2-4a8f-96d5-801725dfdfc3"), NumberOfPassengers = 167 },
                        new { Id = new Guid("a714554f-f363-42f1-b41a-81ee85186661"), Code = "4", CreationDate = new DateTime(2019, 4, 8, 4, 35, 59, 394, DateTimeKind.Local), ModelId = new Guid("7f430a38-a6b2-4a8f-96d5-801725dfdfc4"), NumberOfPassengers = 117 }
                    );
                });

            modelBuilder.Entity("AirPlaneDDD.Domain.Entities.AirPlaneModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AirPlaneModel");

                    b.HasData(
                        new { Id = new Guid("7f430a38-a6b2-4a8f-96d5-801725dfdfc1"), Name = "Airbus A300B1" },
                        new { Id = new Guid("7f430a38-a6b2-4a8f-96d5-801725dfdfc2"), Name = "Airbus A319" },
                        new { Id = new Guid("7f430a38-a6b2-4a8f-96d5-801725dfdfc3"), Name = "Boeing 737-100" },
                        new { Id = new Guid("7f430a38-a6b2-4a8f-96d5-801725dfdfc4"), Name = "Boeing CRJ-100" }
                    );
                });

            modelBuilder.Entity("AirPlaneDDD.Domain.Entities.AirPlane", b =>
                {
                    b.HasOne("AirPlaneDDD.Domain.Entities.AirPlaneModel", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}