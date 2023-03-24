﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OptiLoan.Data;

#nullable disable

namespace OptiLoan.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OptiLoan.Models.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SuperAgentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SuperAgentId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("OptiLoan.Models.MasterAgent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("MasterAgents");
                });

            modelBuilder.Entity("OptiLoan.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("OptiLoan.Models.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("OptiLoan.Models.SuperAgent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<int?>("MasterAgentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MasterAgentId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("SuperAgents");
                });

            modelBuilder.Entity("OptiLoan.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OptiLoan.Models.Agent", b =>
                {
                    b.HasOne("OptiLoan.Models.SuperAgent", "SuperAgent")
                        .WithMany("Agents")
                        .HasForeignKey("SuperAgentId");

                    b.HasOne("OptiLoan.Models.User", "user")
                        .WithOne("Agent")
                        .HasForeignKey("OptiLoan.Models.Agent", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SuperAgent");

                    b.Navigation("user");
                });

            modelBuilder.Entity("OptiLoan.Models.MasterAgent", b =>
                {
                    b.HasOne("OptiLoan.Models.Organization", "Organization")
                        .WithMany("MasterAgents")
                        .HasForeignKey("OrganizationId");

                    b.HasOne("OptiLoan.Models.User", "User")
                        .WithOne("MasterAgent")
                        .HasForeignKey("OptiLoan.Models.MasterAgent", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OptiLoan.Models.Organization", b =>
                {
                    b.HasOne("OptiLoan.Models.User", "user")
                        .WithOne("Organization")
                        .HasForeignKey("OptiLoan.Models.Organization", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("OptiLoan.Models.Staff", b =>
                {
                    b.HasOne("OptiLoan.Models.Organization", "Organization")
                        .WithMany("Staff")
                        .HasForeignKey("OrganizationId");

                    b.HasOne("OptiLoan.Models.User", "user")
                        .WithOne("Staff")
                        .HasForeignKey("OptiLoan.Models.Staff", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("user");
                });

            modelBuilder.Entity("OptiLoan.Models.SuperAgent", b =>
                {
                    b.HasOne("OptiLoan.Models.MasterAgent", "MasterAgent")
                        .WithMany("SuperAgents")
                        .HasForeignKey("MasterAgentId");

                    b.HasOne("OptiLoan.Models.User", "user")
                        .WithOne("SuperAgent")
                        .HasForeignKey("OptiLoan.Models.SuperAgent", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasterAgent");

                    b.Navigation("user");
                });

            modelBuilder.Entity("OptiLoan.Models.MasterAgent", b =>
                {
                    b.Navigation("SuperAgents");
                });

            modelBuilder.Entity("OptiLoan.Models.Organization", b =>
                {
                    b.Navigation("MasterAgents");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("OptiLoan.Models.SuperAgent", b =>
                {
                    b.Navigation("Agents");
                });

            modelBuilder.Entity("OptiLoan.Models.User", b =>
                {
                    b.Navigation("Agent");

                    b.Navigation("MasterAgent");

                    b.Navigation("Organization");

                    b.Navigation("Staff");

                    b.Navigation("SuperAgent");
                });
#pragma warning restore 612, 618
        }
    }
}
