using IndUppClassModels;

namespace Indiv.Uppgiftv2.Services

{
    public interface ICustomer
    {
        public Task<IEnumerable<Customer>> GetAllCustomers();
        public Task<Customer> GetSingleCustomer(int id);
        public Task <IEnumerable<Customer>> SearchForCustomer(string name);
        public Task<Customer> Add(Customer customer);
        public Task<Customer> Delete(int id);
        public Task<Customer> Update(Customer customer);
        //IQuerable
    }
}
