using IndUppClassModels;

namespace Indiv.Uppgiftv2.Services

{
    public interface ICustomer<T>
    {
        public Task<IEnumerable<Customer>> GetAllCustomers();
        public Task<Customer> GetSingleCustomer(int id);
        public Task <IEnumerable<Customer>> SearchForCustomer(string name);
        public Task Add(Customer customer);
        public Task Delete(int id);
        public Task Update(Customer customer);
        //IQuerable
    }
}
