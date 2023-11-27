using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Candid.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Candid.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //this code makes sure the database is re-created on the $5/month Azure tier
            base.OnModelCreating(builder);

            // Set Precision on GPA storage
            builder.Entity<AppUser>().Property(au => au.GPA).HasColumnType("decimal(3,2)");

            // Set Precision on latitude, longitude coordinates
            builder.Entity<Address>().Property(au => au.Lat).HasColumnType("decimal(10,7)");
            builder.Entity<Address>().Property(au => au.Lng).HasColumnType("decimal(10,7)");

            // Store enum as string in db for gender property
            builder.Entity<AppUser>()
                .Property(au => au.Gender)
                .HasConversion(new EnumToStringConverter<Gender>());

            // Store enum as string in db for race property
            builder.Entity<AppUser>()
                .Property(au => au.Ethnicity)
                .HasConversion(new EnumToStringConverter<Ethnicity>());

            // Store status enum as string in database for StudentPosition
            builder.Entity<AppUserPosition>()
            .Property(sp => sp.StatusType)
            .HasConversion(new EnumToStringConverter<StatusType>());

            // Store enum as string for industries
            builder.Entity<Industry>()
            .Property(d => d.IndustryType)
            .HasConversion(new EnumToStringConverter<IndustryTypes>());

            // Store enum as string for majors
            builder.Entity<Major>()
            .Property(d => d.MajorCode)
            .HasConversion(new EnumToStringConverter<MajorCodes>());

            // Store state enum as string for address
            builder.Entity<Address>()
            .Property(d => d.State)
            .HasConversion(new EnumToStringConverter<StateType>());

            // Store position type as string in db for AppUser class
            builder.Entity<AppUser>()
            .Property(d => d.PositionType)
            .HasConversion(new EnumToStringConverter<PositionType>());

            // Store position as stirng in db for Position class
            builder.Entity<Position>()
            .Property(d => d.PositionType)
            .HasConversion(new EnumToStringConverter<PositionType>());

            // Many-to-many for Industry to Company
            builder.Entity<CompanyIndustry>()
                .HasKey(ci => new { ci.CompanyId, ci.IndustryId });

            builder.Entity<CompanyIndustry>()
                .HasOne(ci => ci.Company)
                .WithMany(ci => ci.CompanyIndustries)
                .HasForeignKey(ci => ci.CompanyId);

            builder.Entity<CompanyIndustry>()
                .HasOne(ci => ci.Industry)
                .WithMany(ci => ci.CompanyIndustries)
                .HasForeignKey(ci => ci.IndustryId);

            // Many-to-many for Student to Majors
            builder.Entity<AppUserMajor>()
                .HasKey(aum => new { aum.AppUserId, aum.MajorId });

            builder.Entity<AppUserMajor>()
                .HasOne(aum => aum.AppUser)
                .WithMany(aum => aum.AppUserMajors)
                .HasForeignKey(aum => aum.AppUserId);

            builder.Entity<AppUserMajor>()
                .HasOne(aum => aum.Major)
                .WithMany(aum => aum.AppUserMajors)
                .HasForeignKey(aum => aum.MajorId);

            // Many-to-many Position to Majors
            builder.Entity<PositionMajor>()
                .HasKey(pm => new { pm.PositionId, pm.MajorId });

            builder.Entity<PositionMajor>()
                .HasOne(pm => pm.Position)
                .WithMany(pm => pm.PositionMajors)
                .HasForeignKey(pm => pm.PositionId);

            builder.Entity<PositionMajor>()
                .HasOne(pm => pm.Major)
                .WithMany(pm => pm.PositionMajors)
                .HasForeignKey(pm => pm.MajorId);

            builder.Entity<AppUserPosition>()
                .HasOne(sp => sp.Student)
                .WithMany(sp => sp.AppUserPositions)
                .HasForeignKey(sp => sp.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<AppUserPosition>()
                .HasOne(sp => sp.Position)
                .WithMany(sp => sp.AppUserPositions)
                .HasForeignKey(sp => sp.PositionId)
                .OnDelete(DeleteBehavior.NoAction);

            // Store room enum as string in interview table
            builder.Entity<Interview>()
                .HasOne(i => i.Recruiter)
                .WithMany(r => r.RecruiterInterviews)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Interview>()
            .Property(d => d.Room)
            .HasConversion(new EnumToStringConverter<RoomType>());

            builder.Seed();
        }

        /****** DBSETS ******/
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AppUserMajor> AppUserMajors { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyIndustry> CompanyIndustries { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionMajor> PositionMajors { get; set; }
        public DbSet<AppUserPosition> AppUserPositions { get; set; } // i.e. applications
    }
}
