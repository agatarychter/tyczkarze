using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tyczkarze.DataAccess.Model;

namespace Tyczkarze.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Athlete> Athlete { get; set; }
        public DbSet<Pole> Pole { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<TrainingType> TrainingType { get; set; }
        public DbSet<CompetitionAgeCategory> CompetitionAgeCategory { get; set; }
        public DbSet<Competition> Competition { get; set; }
        public DbSet<CompetitionLevel> CompetitionLevel { get; set; }
        public DbSet<Contest> Contest { get; set; }
        public DbSet<Elimination> Elimination { get; set; }
        public DbSet<Jump> Jump { get; set; }
        public DbSet<JumpStatus> JumpStatus { get; set; }
        public DbSet<JumpType> JumpType { get; set; }
        public DbSet<ExerciseType> ExerciseType { get; set; }
        public DbSet<ExerciseParamDone> ExerciseParamDone { get; set; }
        public DbSet<ExerciseParamType> ExerciseParamType { get; set; }
        public DbSet<ExerciseDone> ExerciseDone { get; set; }
        public DbSet<ExerciseDictTypeParam> ExerciseDictTypeParam { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ExerciseDictTypeParam>().HasKey(combineId => new { combineId.IdExerciseParamType, combineId.IdExerciseType });

            modelBuilder.Entity<ExerciseDictTypeParam>()
                .HasOne(et => et.ExerciseType)
                .WithMany(edtp => edtp.ExerciseDictTypeParams)
                .HasForeignKey(iet => iet.IdExerciseType);

            modelBuilder.Entity<ExerciseDictTypeParam>()
                .HasOne(ept => ept.ExerciseParamType)
                .WithMany(edtp => edtp.ExerciseDictTypeParams)
                .HasForeignKey(iept => iept.IdExerciseParamType);

        }
    }
}
