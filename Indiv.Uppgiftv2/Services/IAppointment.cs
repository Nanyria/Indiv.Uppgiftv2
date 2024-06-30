using IndUppClassModels;

namespace Indiv.Uppgiftv2.Services
{
    public interface IAppointment<T>
    {
        public Task<IEnumerable<Appointment>> GetAllAppointmentsThisWeek();
        public Task<IEnumerable<Appointment>> GetAllAppointmentsThisMonth();

        public Task<Appointment> GetSingle(int id);
        public Task<T> Add(Appointment appointment);
        public Task<T> Delete(int id);
        public Task<T> Update(Appointment appointment);
        public Task<int> SaveChangesAsync();

        //Sätta lagring på appointments här eller under customer?
    }
}
