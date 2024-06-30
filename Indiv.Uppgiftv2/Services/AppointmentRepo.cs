using Indiv.Uppgiftv2.Data;
using Indiv.Uppgiftv2.Methods;
using IndUppClassModels;
using Microsoft.EntityFrameworkCore;

namespace Indiv.Uppgiftv2.Services
{
    public class AppointmentRepo : IAppointment<Appointment>
    {
        private AppDbContext _dbContext;
        public AppointmentRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Appointment> Add(Appointment newAppointment)
        {

            newAppointment.EndTime = newAppointment.StartTime.AddHours(1); // Ensure EndTime is set correctly
            var result = await _dbContext.Appointments.AddAsync(newAppointment);
            await _dbContext.SaveChangesAsync();
            return result.Entity;

            //lägg till något som sparar data.

        }

        public async Task<Appointment> Delete(int appointmentID)
        {
            var result = await _dbContext.Appointments.FirstOrDefaultAsync(a => a.AppointmentID == appointmentID);
            if (result != null)
            {
                _dbContext.Appointments.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsThisMonth()
        {
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            return await _dbContext.Appointments
                .Include(a => a.Customer)
                .Where(a => a.Date >= startOfMonth && a.Date <= endOfMonth)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsThisWeek()
        {
            var startOfWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            var endOfWeek = startOfWeek.AddDays(7).AddSeconds(-1);
            return await _dbContext.Appointments
                .Include(a => a.Customer)
                .Where(a => a.Date >= startOfWeek && a.Date <= endOfWeek)
                .ToListAsync();
        }

        public async Task<Appointment> GetSingle(int id)
        {
            var appointment = await _dbContext.Appointments.Include(a => a.Customer).
                FirstOrDefaultAsync(a => a.AppointmentID == id);
            return appointment;
        }

        public async Task<Appointment> Update(Appointment entity)
        {
            var result = await _dbContext.Appointments.FirstOrDefaultAsync(a => a.AppointmentID == entity.AppointmentID);
            if (result != null)
            { //spara gammal data
                result.Date = entity.Date;
                result.StartTime = entity.StartTime;
                entity.EndTime = entity.StartTime.AddHours(1);
            }
            // Ensures EndTime is set correctly
            await _dbContext.SaveChangesAsync();
            return result;

            //lägg till parameter för att spara data
        }
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // Handle exceptions (logging, etc.) as needed for production
                throw;
            }
        }
    }
}

