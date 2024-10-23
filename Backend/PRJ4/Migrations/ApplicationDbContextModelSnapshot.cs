﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PRJ4.Data;

#nullable disable

namespace PRJ4.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PRJ4.Models.Bruger", b =>
                {
                    b.Property<int>("BrugerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BrugerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrugerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("BrugerId")
                        .HasName("PK__Bruger__6FA2FB30AE403A15");

                    b.ToTable("Bruger", (string)null);
                });

            modelBuilder.Entity("PRJ4.Models.Findtægt", b =>
                {
                    b.Property<int>("Findtægt1")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Findtægt");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Findtægt1"));

                    b.Property<int>("BrugerId")
                        .HasColumnType("int")
                        .HasColumnName("BrugerID");

                    b.Property<DateTime?>("Dato")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Indtægt")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Tekst")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Findtægt1")
                        .HasName("PK__Findtægt__2E1D3E026C53B483");

                    b.HasIndex("BrugerId");

                    b.ToTable("Findtægt", (string)null);
                });

            modelBuilder.Entity("PRJ4.Models.Fudgifter", b =>
                {
                    b.Property<int>("FudgiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FudgiftID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FudgiftId"));

                    b.Property<int>("BrugerId")
                        .HasColumnType("int")
                        .HasColumnName("BrugerID");

                    b.Property<DateTime?>("Dato")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Pris")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Tekst")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("FudgiftId")
                        .HasName("PK__Fudgifte__12BF03E8C7E5D9C7");

                    b.HasIndex("BrugerId");

                    b.ToTable("Fudgifter", (string)null);
                });

            modelBuilder.Entity("PRJ4.Models.Vindtægter", b =>
                {
                    b.Property<int>("VindtægtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("VindtægtID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VindtægtId"));

                    b.Property<int>("BrugerId")
                        .HasColumnType("int")
                        .HasColumnName("BrugerID");

                    b.Property<DateTime?>("Dato")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Indtægt")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Tekst")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("VindtægtId")
                        .HasName("PK__Vindtægt__83BCC36FD3543C24");

                    b.HasIndex("BrugerId");

                    b.ToTable("Vindtægter", (string)null);
                });

            modelBuilder.Entity("PRJ4.Models.Vudgifter", b =>
                {
                    b.Property<int>("VudgiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("VudgiftID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VudgiftId"));

                    b.Property<int>("BrugerId")
                        .HasColumnType("int")
                        .HasColumnName("BrugerID");

                    b.Property<DateTime?>("Dato")
                        .HasColumnType("datetime");

                    b.Property<string>("KategoriId")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("KategoriID");

                    b.Property<decimal>("Pris")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Tekst")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("VudgiftId")
                        .HasName("PK__Vudgifte__7E8DE19A4E24036F");

                    b.HasIndex("BrugerId");

                    b.ToTable("Vudgifter", (string)null);
                });

            modelBuilder.Entity("PRJ4.Models.Findtægt", b =>
                {
                    b.HasOne("PRJ4.Models.Bruger", "Bruger")
                        .WithMany("Findtægts")
                        .HasForeignKey("BrugerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Findtægt__Bruger__4222D4EF");

                    b.Navigation("Bruger");
                });

            modelBuilder.Entity("PRJ4.Models.Fudgifter", b =>
                {
                    b.HasOne("PRJ4.Models.Bruger", "Bruger")
                        .WithMany("Fudgifters")
                        .HasForeignKey("BrugerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Fudgifter__Bruge__3C69FB99");

                    b.Navigation("Bruger");
                });

            modelBuilder.Entity("PRJ4.Models.Vindtægter", b =>
                {
                    b.HasOne("PRJ4.Models.Bruger", "Bruger")
                        .WithMany("Vindtægters")
                        .HasForeignKey("BrugerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Vindtægte__Bruge__3F466844");

                    b.Navigation("Bruger");
                });

            modelBuilder.Entity("PRJ4.Models.Vudgifter", b =>
                {
                    b.HasOne("PRJ4.Models.Bruger", "Bruger")
                        .WithMany("Vudgifters")
                        .HasForeignKey("BrugerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Vudgifter__Bruge__398D8EEE");

                    b.Navigation("Bruger");
                });

            modelBuilder.Entity("PRJ4.Models.Bruger", b =>
                {
                    b.Navigation("Findtægts");

                    b.Navigation("Fudgifters");

                    b.Navigation("Vindtægters");

                    b.Navigation("Vudgifters");
                });
#pragma warning restore 612, 618
        }
    }
}
