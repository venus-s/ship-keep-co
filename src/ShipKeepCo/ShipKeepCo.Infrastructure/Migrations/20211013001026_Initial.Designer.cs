// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShipKeepCo.Infrastructure;

namespace ShipKeepCo.Infrastructure.Migrations
{
    [DbContext(typeof(ShipKeepCoContext))]
    [Migration("20211013001026_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShipKeepCo.Domain.Entities.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArrivalVoyagePointId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartureVoyagePointId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("BookingId");

                    b.HasIndex("ArrivalVoyagePointId");

                    b.HasIndex("DepartureVoyagePointId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("ShipKeepCo.Domain.Entities.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("ShipKeepCo.Domain.Entities.PricePerNight", b =>
                {
                    b.Property<int>("PricePerNightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("PricePerNightId");

                    b.ToTable("PricePerNights");
                });

            modelBuilder.Entity("ShipKeepCo.Domain.Entities.Voyage", b =>
                {
                    b.Property<int>("VoyageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VoyageId");

                    b.ToTable("Voyages");
                });

            modelBuilder.Entity("ShipKeepCo.Domain.Entities.VoyagePoint", b =>
                {
                    b.Property<int>("VoyagePointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("VoyageId")
                        .HasColumnType("int");

                    b.HasKey("VoyagePointId");

                    b.HasIndex("LocationId");

                    b.HasIndex("VoyageId");

                    b.ToTable("VoyagePoints");
                });

            modelBuilder.Entity("ShipKeepCo.Domain.Entities.Booking", b =>
                {
                    b.HasOne("ShipKeepCo.Domain.Entities.VoyagePoint", "ArrivalVoyagePoint")
                        .WithMany()
                        .HasForeignKey("ArrivalVoyagePointId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ShipKeepCo.Domain.Entities.VoyagePoint", "DepartureVoyagePoint")
                        .WithMany()
                        .HasForeignKey("DepartureVoyagePointId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ArrivalVoyagePoint");

                    b.Navigation("DepartureVoyagePoint");
                });

            modelBuilder.Entity("ShipKeepCo.Domain.Entities.VoyagePoint", b =>
                {
                    b.HasOne("ShipKeepCo.Domain.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ShipKeepCo.Domain.Entities.Voyage", "Voyage")
                        .WithMany("VoyagePoints")
                        .HasForeignKey("VoyageId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Voyage");
                });

            modelBuilder.Entity("ShipKeepCo.Domain.Entities.Voyage", b =>
                {
                    b.Navigation("VoyagePoints");
                });
#pragma warning restore 612, 618
        }
    }
}
