using IndUppClassModels;

namespace Indiv.Uppgiftv2.Services
{
    public interface IAppointment<T>
    {
        public Task<IEnumerable<Appointment>> GetAllAppointmentsThisWeek();
        public Task<IEnumerable<Appointment>> GetAllAppointmentsThisMonth();


        public Task Add(Appointment appointment);
        public Task Delete(Appointment appointment);
        public Task Update(Appointment appointment);
    }
}
