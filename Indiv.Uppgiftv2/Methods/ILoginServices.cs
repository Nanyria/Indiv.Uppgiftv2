namespace Indiv.Uppgiftv2.Methods
{
    public interface ILoginServices<T>
    {
        void LogIn();
        void Logout(int id);
        void SearchAppointments(int id);
        void ChangeAppointment(int id);
    }
}
