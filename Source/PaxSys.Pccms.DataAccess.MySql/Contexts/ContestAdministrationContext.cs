using Microsoft.EntityFrameworkCore;
using PaxSys.Pccms.Domain.Models;

namespace PaxSys.Pccms.DataAccess.MySql.Contexts
{
    public class ContestAdministrationContext : DbContext
    {
        public static ContestAdministrationContext Create(string connectionString)
        {   
            return new ContestAdministrationContext(new DbContextOptionsBuilder()
                .UseMySql(connectionString)
                .Options);
        }

        private ContestAdministrationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contest> Contests { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<MemberActivityAttendance> MemberActivityAttendances { get; set; }
        public DbSet<TeamActivityAttendance> TeamActivityAttendances { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contest>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Group>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Member>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Activity>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Team>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<MemberActivityAttendance>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<TeamActivityAttendance>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Contest>().HasMany(x => x.AttendingGroups);
            modelBuilder.Entity<Contest>().HasMany(x => x.Activities);
            modelBuilder.Entity<Group>().HasMany(x => x.GroupMembers);
            modelBuilder.Entity<Group>().HasMany(x => x.GroupMembers);
            modelBuilder.Entity<Member>().HasMany(x => x.ActivityResults);
            modelBuilder.Entity<Member>().HasMany(x => x.AttendedTeams);
            modelBuilder.Entity<TeamMember>().HasKey(bc => new { bc.TeamId, bc.MemberId });
            modelBuilder.Entity<TeamMember>().HasOne(bc => bc.Team).WithMany(b => b.TeamMembers).HasForeignKey(bc => bc.MemberId);
            modelBuilder.Entity<TeamMember>().HasOne(bc => bc.Member).WithMany(c => c.AttendedTeams).HasForeignKey(bc => bc.TeamId);

            base.OnModelCreating(modelBuilder);
        }
    }
}