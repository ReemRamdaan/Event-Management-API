using Event_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_Management.Data
{
    public class EventContext:DbContext
    {
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Organiser> Organisers { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
       .HasIndex(t => new { t.AttendanceId, t.EventId })
       .IsUnique();
            modelBuilder.Entity<Ticket>().HasIndex(t => t.AttendanceId).IsUnique(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
