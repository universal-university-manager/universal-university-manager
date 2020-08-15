﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UUM.Infrastructure.Migrations
{
    [DbContext(typeof(Context.Context))]
    [Migration("20200815032937_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-preview.7.20365.15");

            modelBuilder.Entity("UUM.Model.ViewModels.AddressModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Number")
                        .HasColumnType("tinyint");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserModelId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserModelId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("UUM.Model.ViewModels.CourseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("BanknoteDeliveryPeriod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Curriculum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EvaluationPeriods")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolPeriods")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("UUM.Model.ViewModels.LoginModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserModelId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("UUM.Model.ViewModels.ReportCardModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("AverageGrade")
                        .HasColumnType("real");

                    b.Property<float>("Exa")
                        .HasColumnType("real");

                    b.Property<byte>("Fouls")
                        .HasColumnType("tinyint");

                    b.Property<string>("Frequency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("P1")
                        .HasColumnType("real");

                    b.Property<float>("P2")
                        .HasColumnType("real");

                    b.Property<byte>("Presence")
                        .HasColumnType("tinyint");

                    b.Property<float>("Sub")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("UUM.Model.ViewModels.StudentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("CompletionDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("LockoutDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReportCardId")
                        .HasColumnType("int");

                    b.Property<string>("TransferDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CourseId");

                    b.HasIndex("ReportCardId");

                    b.HasIndex("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("UUM.Model.ViewModels.TeachingUnitModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeUnit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("TeachingUnits");
                });

            modelBuilder.Entity("UUM.Model.ViewModels.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte>("Age")
                        .HasColumnType("tinyint");

                    b.Property<string>("CpfCnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UUM.Model.ViewModels.AddressModel", b =>
                {
                    b.HasOne("UUM.Model.ViewModels.UserModel", null)
                        .WithMany("Address")
                        .HasForeignKey("UserModelId");
                });

            modelBuilder.Entity("UUM.Model.ViewModels.CourseModel", b =>
                {
                    b.HasOne("UUM.Model.ViewModels.AddressModel", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("UUM.Model.ViewModels.LoginModel", b =>
                {
                    b.HasOne("UUM.Model.ViewModels.UserModel", null)
                        .WithMany("Logins")
                        .HasForeignKey("UserModelId");
                });

            modelBuilder.Entity("UUM.Model.ViewModels.StudentModel", b =>
                {
                    b.HasOne("UUM.Model.ViewModels.AddressModel", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("UUM.Model.ViewModels.CourseModel", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("UUM.Model.ViewModels.ReportCardModel", "ReportCard")
                        .WithMany()
                        .HasForeignKey("ReportCardId");

                    b.HasOne("UUM.Model.ViewModels.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("UUM.Model.ViewModels.TeachingUnitModel", b =>
                {
                    b.HasOne("UUM.Model.ViewModels.AddressModel", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });
#pragma warning restore 612, 618
        }
    }
}
