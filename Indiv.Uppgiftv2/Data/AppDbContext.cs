using IndUppClassModels;
using Microsoft.EntityFrameworkCore;

namespace Indiv.Uppgiftv2.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //mapping Appointment
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.CustomerID);
            //SeedData

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 1001,
                FirstName = "Andrea",
                LastName = "Almer",
                PassWord = "abC321"
                
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 1002,
                FirstName = "Beata",
                LastName = "Almer",
                PassWord = "123Fyra"
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentID = 1001,
                CustomerID = 1001,
                Date = new DateTime(2024, 7, 1),
                StartTime = new DateTime(2024, 7, 1, 9, 0, 0),
                EndTime = new DateTime(2024, 7, 1, 10, 0, 0),
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentID = 1002,
                CustomerID = 1001,
                Date = new DateTime(2024, 7, 4),
                StartTime = new DateTime(2024, 7, 4, 9, 0, 0),
                EndTime = new DateTime(2024, 7, 4, 10, 0, 0),
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentID = 1003,
                CustomerID = 1001,
                Date = new DateTime(2024, 7, 8),
                StartTime = new DateTime(2024, 7, 8, 9, 0, 0),
                EndTime = new DateTime(2024, 7, 8, 10, 0, 0),
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentID = 1004,
                CustomerID = 1002,
                Date = new DateTime(2024, 7, 1),
                StartTime = new DateTime(2024, 7, 1, 10, 0, 0),
                EndTime = new DateTime(2024, 7, 1, 11, 0, 0),
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentID = 1005,
                CustomerID = 1002,
                Date = new DateTime(2024, 7, 2),
                StartTime = new DateTime(2024, 7, 2, 13, 0, 0),
                EndTime = new DateTime(2024, 7, 2, 14, 0, 0),
            });

        }
    }
}
