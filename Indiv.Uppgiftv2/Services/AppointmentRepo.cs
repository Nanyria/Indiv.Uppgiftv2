using IndUppClassModels;

namespace Indiv.Uppgiftv2.Services
{
    public class AppointmentRepo : IAppointment<Appointment>
    {
        public Task Add(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> GetAllAppointmentsThisMonth()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> GetAllAppointmentsThisWeek()
        {
            throw new NotImplementedException();
        }

        public Task Update(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
