﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tyczkarze.DataAccess.Data;

namespace Tyczkarze.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191027172600_AllEntities")]
    partial class AllEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Tyczkarze.Model.Athlete", b =>
                {
                    b.Property<int>("IdAthlete")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("GUID");

                    b.Property<decimal?>("Height");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Surname");

                    b.Property<decimal?>("Weight");

                    b.HasKey("IdAthlete");

                    b.ToTable("Athlete");
                });

            modelBuilder.Entity("Tyczkarze.Model.Competition", b =>
                {
                    b.Property<int>("IdCompetition")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BeginDate");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime?>("EndDate");

                    b.Property<int>("IdAgeCategory");

                    b.Property<int>("IdAthlete");

                    b.Property<int>("IdLevel");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.HasKey("IdCompetition");

                    b.HasIndex("IdAthlete");

                    b.ToTable("Competition");
                });

            modelBuilder.Entity("Tyczkarze.Model.CompetitionAgeCategory", b =>
                {
                    b.Property<int>("IdAgeCategory")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("MaxAge");

                    b.Property<int?>("MinAge");

                    b.Property<string>("NameAgeCategory");

                    b.HasKey("IdAgeCategory");

                    b.ToTable("CompetitionAgeCategory");
                });

            modelBuilder.Entity("Tyczkarze.Model.CompetitionLevel", b =>
                {
                    b.Property<int>("IdLevel")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("LevelName");

                    b.Property<string>("Note");

                    b.HasKey("IdLevel");

                    b.ToTable("CompetitionLevel");
                });

            modelBuilder.Entity("Tyczkarze.Model.Contest", b =>
                {
                    b.Property<int>("IdContest")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ContestDate");

                    b.Property<int>("IdCompetition");

                    b.Property<string>("Note");

                    b.HasKey("IdContest");

                    b.ToTable("Contest");
                });

            modelBuilder.Entity("Tyczkarze.Model.Elimination", b =>
                {
                    b.Property<int>("IdElimination")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EliminationDate");

                    b.Property<int>("IdCompetition");

                    b.Property<string>("Note");

                    b.HasKey("IdElimination");

                    b.ToTable("Elimination");
                });

            modelBuilder.Entity("Tyczkarze.Model.Exercise", b =>
                {
                    b.Property<int>("IdExercise")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Distance");

                    b.Property<int?>("ExerciseCount");

                    b.Property<string>("ExerciseName");

                    b.Property<decimal?>("Height");

                    b.Property<int?>("IdPole");

                    b.Property<int>("IdTraining");

                    b.Property<int?>("JumpType");

                    b.Property<string>("Note");

                    b.Property<int?>("SeriesCount");

                    b.Property<bool?>("Spikes");

                    b.Property<int?>("StepsCount");

                    b.Property<int?>("Time");

                    b.Property<decimal?>("Weight");

                    b.HasKey("IdExercise");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("Tyczkarze.Model.ExerciseDictTypeParam", b =>
                {
                    b.Property<int>("IdExerciseParamType");

                    b.Property<int>("IdExerciseType");

                    b.HasKey("IdExerciseParamType", "IdExerciseType");

                    b.ToTable("ExerciseDictTypeParam");
                });

            modelBuilder.Entity("Tyczkarze.Model.ExerciseDone", b =>
                {
                    b.Property<int>("IdExerciseDone")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdTraining");

                    b.HasKey("IdExerciseDone");

                    b.ToTable("ExerciseDone");
                });

            modelBuilder.Entity("Tyczkarze.Model.ExerciseParamDone", b =>
                {
                    b.Property<int>("IdExerciseParam")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdExerciseDone");

                    b.Property<int>("IdExerciseParamType");

                    b.Property<string>("Value");

                    b.HasKey("IdExerciseParam");

                    b.ToTable("ExerciseParam");
                });

            modelBuilder.Entity("Tyczkarze.Model.ExerciseParamType", b =>
                {
                    b.Property<int>("IdParamType")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsObligatory");

                    b.Property<string>("ParamName");

                    b.Property<string>("ParamType");

                    b.HasKey("IdParamType");

                    b.ToTable("ExerciseParamType");
                });

            modelBuilder.Entity("Tyczkarze.Model.ExerciseType", b =>
                {
                    b.Property<int>("IdExerciseType")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("ExerciseTypeName");

                    b.HasKey("IdExerciseType");

                    b.ToTable("ExerciseType");
                });

            modelBuilder.Entity("Tyczkarze.Model.Jump", b =>
                {
                    b.Property<int>("IdJump")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Height");

                    b.Property<int?>("IdContest");

                    b.Property<int?>("IdElimination");

                    b.Property<int?>("IdJumpStatus1");

                    b.Property<int?>("IdJumpStatus2");

                    b.Property<int?>("IdJumpStatus3");

                    b.Property<int?>("IdPole1");

                    b.Property<int?>("IdPole2");

                    b.Property<int?>("IdPole3");

                    b.Property<int>("JumpType");

                    b.Property<string>("Note");

                    b.Property<int?>("StepsCount");

                    b.HasKey("IdJump");

                    b.ToTable("Jump");
                });

            modelBuilder.Entity("Tyczkarze.Model.JumpStatus", b =>
                {
                    b.Property<int>("IdJumpStatus")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("IdJumpStatus");

                    b.ToTable("JumpStatus");
                });

            modelBuilder.Entity("Tyczkarze.Model.JumpType", b =>
                {
                    b.Property<int>("IdJumpType")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("IdJumpType");

                    b.ToTable("JumpType");
                });

            modelBuilder.Entity("Tyczkarze.Model.Pole", b =>
                {
                    b.Property<int>("IdPole")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color");

                    b.Property<decimal?>("Hardness");

                    b.Property<int>("IdAthlete");

                    b.Property<decimal?>("Length");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.Property<string>("NameByAthlete");

                    b.Property<string>("Note");

                    b.Property<string>("Type");

                    b.HasKey("IdPole");

                    b.HasIndex("IdAthlete");

                    b.ToTable("Pole");
                });

            modelBuilder.Entity("Tyczkarze.Model.Training", b =>
                {
                    b.Property<int>("IdTraining")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdAthlete");

                    b.Property<int>("IdTrainer");

                    b.Property<int>("IdTrainingType");

                    b.Property<DateTime?>("TrainingDateTime");

                    b.HasKey("IdTraining");

                    b.HasIndex("IdAthlete");

                    b.ToTable("Training");
                });

            modelBuilder.Entity("Tyczkarze.Model.TrainingType", b =>
                {
                    b.Property<int>("IdTrainingType")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("IdExerciseType");

                    b.Property<string>("TrainingName");

                    b.HasKey("IdTrainingType");

                    b.ToTable("TrainingType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tyczkarze.Model.Competition", b =>
                {
                    b.HasOne("Tyczkarze.Model.Athlete")
                        .WithMany("Competitions")
                        .HasForeignKey("IdAthlete")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tyczkarze.Model.Pole", b =>
                {
                    b.HasOne("Tyczkarze.Model.Athlete")
                        .WithMany("Poles")
                        .HasForeignKey("IdAthlete")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tyczkarze.Model.Training", b =>
                {
                    b.HasOne("Tyczkarze.Model.Athlete")
                        .WithMany("Trainings")
                        .HasForeignKey("IdAthlete")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
