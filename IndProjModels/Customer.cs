namespace IndUppClassModels
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassWord { get; set; }

        public List<Appointment> Appointments { get; set; }

        
        
    }
}
