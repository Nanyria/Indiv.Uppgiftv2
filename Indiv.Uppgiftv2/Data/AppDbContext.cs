using IndProjModels;
using IndUppClassModels;
using Microsoft.EntityFrameworkCore;

namespace Indiv.Uppgiftv2.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentChanges> AppointmentChanges { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //mapping Appointment
            // Configure relationship for Appointment and Customer
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.CustomerID);

            // Configure relationship for Appointment and AppointmentChange
            modelBuilder.Entity<Appointment>()
                .HasMany(a => a.Changes)
                .WithOne(ac => ac.Appointment) // AppointmentChange references Appointment
                .HasForeignKey(ac => ac.AppointmentID); // Foreign key in AppointmentChange


            modelBuilder.Entity<AppointmentChanges>()
               .HasKey(ac => ac.AppointmentChangeID); // Define AppointmentChangeID as primary key

            modelBuilder.Entity<AppointmentChanges>()
                .HasOne(ac => ac.Appointment)
                .WithMany(a => a.Changes)
                .HasForeignKey(ac => ac.AppointmentID);
            //SeedData

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 1001,
                Username = "AA1001",
                FirstName = "Andrea",
                LastName = "Almer",
                PassWord = "abC321"
                
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 1002,
                Username = "BA1002",
                FirstName = "Beata",
                LastName = "Almer",
                PassWord = "123Fyra"
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentID = 1001,
                CustomerID = 1001,
                Date = new DateTime(2024, 6, 1),
                StartTime = new DateTime(2024, 6, 1, 9, 0, 0),
                EndTime = new DateTime(2024, 6, 1, 10, 0, 0),
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentID = 1002,
                CustomerID = 1001,
                Date = new DateTime(2024, 6, 4),
                StartTime = new DateTime(2024, 6, 4, 9, 0, 0),
                EndTime = new DateTime(2024, 6, 4, 10, 0, 0),
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentID = 1003,
                CustomerID = 1001,
                Date = new DateTime(2024, 6, 8),
                StartTime = new DateTime(2024, 6, 8, 9, 0, 0),
                EndTime = new DateTime(2024, 6, 8, 10, 0, 0),
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentID = 1004,
                CustomerID = 1002,
                Date = new DateTime(2024, 6, 1),
                StartTime = new DateTime(2024, 6, 1, 10, 0, 0),
                EndTime = new DateTime(2024, 6, 1, 11, 0, 0),
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentID = 1005,
                CustomerID = 1002,
                Date = new DateTime(2024, 6, 2),
                StartTime = new DateTime(2024, 6, 2, 13, 0, 0),
                EndTime = new DateTime(2024, 6, 2, 14, 0, 0),
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 1001,
                UserName = "Admin1001",
                EFirstName = "Admin",
                ELastName = "AdminLastName",
                EPassWord = "123Password"
            });

        }
    }
}
