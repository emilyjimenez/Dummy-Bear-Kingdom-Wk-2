using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DummyBearKingdom.Models;

namespace DummyBearKingdom.Migrations
{
    [DbContext(typeof(DummyBearKingdomDbContext))]
    [Migration("20180123193451_UpdateDBContext")]
    partial class UpdateDBContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("DummyBearKingdom.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DummyBearKingdom.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("Content");

                    b.Property<int>("ProductId");

                    b.Property<int>("Rating");

                    b.HasKey("ReviewId");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("DummyBearKingdom.Models.Review", b =>
                {
                    b.HasOne("DummyBearKingdom.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
