﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Reborn.Fashion.Infrastructure;

#nullable disable

namespace Reborn.Fashion.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Reborn.Fashion.Domain.Entities.Bid", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ListingId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.ToTable("Bid");
                });

            modelBuilder.Entity("Reborn.Fashion.Domain.Entities.Listing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal?>("Reserve")
                        .HasColumnType("numeric");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("Reborn.Fashion.Domain.Entities.Bid", b =>
                {
                    b.HasOne("Reborn.Fashion.Domain.Entities.Listing", null)
                        .WithMany("Bids")
                        .HasForeignKey("ListingId");
                });

            modelBuilder.Entity("Reborn.Fashion.Domain.Entities.Listing", b =>
                {
                    b.OwnsOne("Reborn.Fashion.Domain.ValueObjects.DateRange", "DateRange", b1 =>
                        {
                            b1.Property<Guid>("ListingId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime?>("End")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("ListingId");

                            b1.ToTable("Listings");

                            b1.WithOwner()
                                .HasForeignKey("ListingId");
                        });

                    b.Navigation("DateRange");
                });

            modelBuilder.Entity("Reborn.Fashion.Domain.Entities.Listing", b =>
                {
                    b.Navigation("Bids");
                });
#pragma warning restore 612, 618
        }
    }
}
